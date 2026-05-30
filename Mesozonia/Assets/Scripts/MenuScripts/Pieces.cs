using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pieces : MonoBehaviour
{

    private int piecesLeft = 3;
    [SerializeField] Text pieceText;

    AudioScript audioscript;

    private void Awake()
    {
        audioscript = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioScript>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Piece"))
        {
            audioscript.playSFX(audioscript.piecesSFX);
            Destroy(collision.gameObject);
            piecesLeft--;
            pieceText.text = "PIECES LEFT: " + piecesLeft;
            checkPiecesLeft();
        }
    }

    private void checkPiecesLeft() {
        if (piecesLeft == 0) {
            SceneManager.LoadScene("VictoryScene");
        }
    }
}
