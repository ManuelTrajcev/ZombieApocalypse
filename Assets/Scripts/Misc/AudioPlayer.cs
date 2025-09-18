using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer instance;
    
    
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
