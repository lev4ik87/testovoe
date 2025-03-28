using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private HookSphereDrop hookSphereDrop;  

    public override void InstallBindings()
    {
        this.Container
             .Bind<ScoreController>()
             .FromInstance(this.scoreController)
             .AsSingle();

        this.Container
            .Bind<HookSphereDrop>()
            .FromInstance(this.hookSphereDrop)
            .AsSingle();
   
    }
}
