using System.Collections;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    [Header("Disparo del enemigo")]
    [SerializeField] private Transform controlador;
    [SerializeField] private GameObject Bala;
    [SerializeField] private float tiempoEntreDisapro;
    [SerializeField] private float velocidad;
    private Animator animator;

    void Start()
    {
        InvokeRepeating(nameof(Disparar), 0f, tiempoEntreDisapro);
        animator = GetComponent<Animator>();
    }

    public void Disparar()
    {
        GameObject bala = Instantiate(Bala, controlador.position, controlador.rotation);
        StartCoroutine(AnimacionDisparo());
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(0, -1) * velocidad;
        }
    }
    IEnumerator AnimacionDisparo()
    {
        animator.SetTrigger("Disparo");
        yield return new WaitForSeconds(0.37f); // tiempo para la animación de disparo
        animator.SetTrigger("Normal");
     }
}
