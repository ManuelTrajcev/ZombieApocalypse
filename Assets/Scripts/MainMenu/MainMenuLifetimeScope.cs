using UnityEngine;
using VContainer;
using VContainer.Unity;

public class MainMenuLifetimeScope : LifetimeScope
{
    [SerializeField] GameManager gameManager;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<MainMenuManager>(Lifetime.Singleton);
        builder.RegisterComponent(gameManager);
    }
}