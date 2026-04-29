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
        if (Input.GetKeyDown(KeyCode.K))
        {
            //player.stateMachine.ChangeState();
            Debug.Log("mmiau");
        }
    }
    public void Exit()
    {

    }
}
