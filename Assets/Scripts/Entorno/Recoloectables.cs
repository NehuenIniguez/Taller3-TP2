using System.Collections;
using UnityEngine;

public class Recoloectables : MonoBehaviour
{
    public int puntos = 1;
    [SerializeField] private Puntaje puntaje;
    private AudioSource audioSource;
    public AudioClip sonido;
    private Animator animator;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Personaje"))
        {
            StartCoroutine(Recolectar());
        }
    }

    private IEnumerator Recolectar()
    {
        animator.SetTrigger("Recolectado");
        puntaje.SumaPuntos(puntos);
        AudioSource.PlayClipAtPoint(sonido, transform.position);
        
        yield return new WaitForSeconds(0.5f); // Espera antes de destruir

        Destroy(gameObject);
    }
}
