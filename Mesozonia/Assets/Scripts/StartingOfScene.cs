using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;


public class StartingOfScene : MonoBehaviour
{
    public string playerNameFile;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StaticStates.InitializeStaticStates(playerNameFile);

    }

    private void Update()
    {
        StaticStates.stateMachine.GetState().Update();
    }
}
