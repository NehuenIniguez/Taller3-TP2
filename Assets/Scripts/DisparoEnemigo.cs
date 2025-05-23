using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    [Header("Disparo del enemigo")]
    [SerializeField] private Transform controlador;
    [SerializeField] private GameObject Bala;
    [SerializeField] private float tiempoEntreDisapro;
    [SerializeField] private float velocidad;

    void Start()
    {
        InvokeRepeating(nameof(Disparar), 0f, tiempoEntreDisapro);   
    }

    public void Disparar()
    {
        GameObject bala = Instantiate(Bala, controlador.position, Quaternion.identity);
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(0, -1) * velocidad;
         }
    }
}
