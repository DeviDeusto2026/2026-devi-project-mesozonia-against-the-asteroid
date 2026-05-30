using UnityEngine;
using static UnityEngine.SpriteMask;

public class AudioScript : MonoBehaviour
{

    [Header ("---Audio Sources---")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---Audio Clips---")]
    public AudioClip music;
    public AudioClip piecesSFX;
    public AudioClip jumpSFX;
    public AudioClip walkSFX;
    public AudioClip runSFX;
    public AudioClip buttonSFX;
    public AudioClip DBcharge;
    public AudioClip DBrelease;


    private void Start()
    {
        musicSource.clip = music;
        musicSource.Play();
    }

    public void playSFX(AudioClip clip) { 
        SFXSource.PlayOneShot(clip);    
    }

    public void StartWalking()
    {
        if (!SFXSource.isPlaying)
        {
            SFXSource.clip = walkSFX;
            SFXSource.loop = true;
            SFXSource.Play();
        }
    }

    public void StopWalking()
    {
        SFXSource.Stop();
    }


    public void StartRunning()
    {
        if (!SFXSource.isPlaying)
        {
            SFXSource.clip = runSFX;
            SFXSource.loop = true;
            SFXSource.Play();
        }
    }

    public void StopRunning()
    {
        SFXSource.Stop();
    }
}
