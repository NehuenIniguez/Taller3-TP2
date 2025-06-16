using UnityEngine;

public class Recoloectables : MonoBehaviour
{
    public int puntos = 1;
    [SerializeField] private Puntaje puntaje;
    private AudioSource audioSource;
    public AudioClip sonido;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Personaje"))
        {
            
            puntaje.SumaPuntos(puntos);
            AudioSource.PlayClipAtPoint(sonido, transform.position);
            Destroy(gameObject);
            
        }
    }
}
