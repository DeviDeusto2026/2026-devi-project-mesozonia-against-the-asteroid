using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pieces : MonoBehaviour
{

    public int piecesLeft = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name == "Piece")
    //    {
    //        Destroy(other.gameObject);
    //        piecesLeft--;
    //        checkPiecesLeft();
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Piece"))
        {
            Destroy(collision.gameObject);
            piecesLeft--;
            checkPiecesLeft();
        }
    }

    private void checkPiecesLeft() {
        if (piecesLeft == 0) {
            SceneManager.LoadScene("VictoryScene");
        }
    }
}
