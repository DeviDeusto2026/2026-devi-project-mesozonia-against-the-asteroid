using Unity.VisualScripting;
using UnityEngine;

public class StartingOfScene : MonoBehaviour
{
    private GameObject player;
    private Movement mv;
    private StateMachine stateMachine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = this.gameObject;
        stateMachine = new StateMachine();
        mv = new Movement(player, stateMachine);

        mv.stateMachine.ChangeState(new IdleState(mv));
    }

    private void Update()
    {
       stateMachine.Update();
    }
}
