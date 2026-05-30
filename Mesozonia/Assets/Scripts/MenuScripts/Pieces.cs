using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pieces : MonoBehaviour
{

    [SerializeField] Text pieceText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerData.piecesLeft = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Piece"))
        {
            Destroy(collision.gameObject);
            PlayerData.piecesLeft--;
            Debug.Log(PlayerData.piecesLeft);
            pieceText.text = "PIECES LEFT: " + PlayerData.piecesLeft;
            checkPiecesLeft();
        }
    }

    private void checkPiecesLeft() {
        if (PlayerData.piecesLeft == 0) {
            SceneManager.LoadScene("VictoryScene");
        }
    }
}
