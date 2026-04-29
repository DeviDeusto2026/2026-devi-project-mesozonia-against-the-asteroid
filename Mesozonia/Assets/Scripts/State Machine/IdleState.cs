using UnityEngine;

public class IdleState : IState
{
    private Movement player;
    public IdleState(Movement player)
    {
        this.player = player;
    }

    public void Enter()
    {
        Debug.Log("IdleState Entrado");
    }

    public void Update()
    {

    }
    public void Exit()
    {

    }
}
