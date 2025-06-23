using UnityEngine;

public class audio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sonido;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PausarAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }
}
