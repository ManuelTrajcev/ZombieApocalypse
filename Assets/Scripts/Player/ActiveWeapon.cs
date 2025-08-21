using Cinemachine;
using StarterAssets;
using TMPro;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera playerCamera;
    [SerializeField] private Camera weaponCamera;
    [SerializeField] GameObject zoomVignette;
    [SerializeField] TMP_Text ammoText;
    FirstPersonController fpsController;
    const string SHOOT_STRING = "Shoot";
    [SerializeField] private WeaponSO currentWeaponSO;
    StarterAssetsInputs starterAssetsInputs;
    private Animator animator;
    private Weapon currentWeapon;
    private float timeSinceLastShot;
    float defaultFOV;
    float defaultRotationSpeed;
    private int currentAmmo;

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        defaultFOV = playerCamera.m_Lens.FieldOfView;
        fpsController = GetComponentInParent<FirstPersonController>();
        defaultRotationSpeed = fpsController.RotationSpeed;
    }

    void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
        AdjustAmo(currentWeaponSO.MagazineSize);
    }

    void Update()
    {
        HandleShoot();
        HandleZoom();
    }

    public void AdjustAmo(int amount)
    {
        currentAmmo += amount;
        if (currentAmmo > currentWeaponSO.MagazineSize)
        {
            currentAmmo = currentWeaponSO.MagazineSize;
        }
        ammoText.text = currentAmmo.ToString("D2");
    }

    void HandleShoot()
    {
        timeSinceLastShot += Time.deltaTime;

        if (!starterAssetsInputs.shoot) return;
        if (timeSinceLastShot >= currentWeaponSO.FireRate && currentAmmo > 0)
        {
            string shootString = currentWeaponSO.name + SHOOT_STRING;
            Debug.Log(shootString);
            Debug.Log(animator.bodyPosition);
            currentWeapon.Shoot(currentWeaponSO);
            animator.Play(shootString, 0, 0f);
            timeSinceLastShot = 0;
            AdjustAmo(-1);
        }
        else
        {
            animator.StopPlayback();
        }

        if (!currentWeaponSO.IsAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }
    }

    public void SwitchWeapon(WeaponSO pickedUpWeaponSo)
    {
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }

        Weapon newWeapon = Instantiate(pickedUpWeaponSo.WeaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.currentWeaponSO = pickedUpWeaponSo;
        AdjustAmo(currentWeaponSO.MagazineSize);;
    }

    void HandleZoom()
    {
        if (!currentWeaponSO.CanZoom)
        {
            return;
        }

        if (starterAssetsInputs.zoom)
        {
            playerCamera.m_Lens.FieldOfView = currentWeaponSO.ZoomAmount;
            zoomVignette.SetActive(true);
            weaponCamera.fieldOfView = currentWeaponSO.ZoomAmount;
            fpsController.ChangeRotationSpeed(currentWeaponSO.ZoomRotationSpeed);
        }
        else
        {
            playerCamera.m_Lens.FieldOfView = defaultFOV;
            zoomVignette.SetActive(false);
            weaponCamera.fieldOfView = defaultFOV;
            fpsController.ChangeRotationSpeed(defaultRotationSpeed);
        }
    }
}