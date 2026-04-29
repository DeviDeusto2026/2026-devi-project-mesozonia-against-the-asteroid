using Unity.VisualScripting;
using UnityEngine;

public class StartingOfScene : MonoBehaviour
{
    private GameObject player;
    private Movement mv;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = this.gameObject;
        mv = new Movement();
        mv.stateMachine.ChangeState(new IdleState(mv));
    }
}
