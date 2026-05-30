using UnityEngine;

public class AudioScript : MonoBehaviour
{

    [Header ("---Audio Sources---")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---Audio Clips---")]
    public AudioClip music;
    public AudioClip piecesSFX;


    private void Start()
    {
        musicSource.clip = music;
        musicSource.Play();
    }

    public void playSFX(AudioClip clip) { 
        SFXSource.PlayOneShot(clip);    
    }
}
