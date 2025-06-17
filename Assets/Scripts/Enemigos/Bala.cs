using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float danio = 1;
    [SerializeField] private float tiempoDeVida = 2f;
    private Transform jugador;
    private float velocidadActual;
    void Start()
    {
        jugador = GameObject.FindWithTag("Personaje").transform;
        velocidadActual = velocidad;
        //jugador.GetComponent<Vida_Pj>().TomarDanio(danio);
        Destroy(gameObject, tiempoDeVida);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Personaje"))
        {
            other.GetComponent<Vida_Pj>().TomarDanio(danio);
            Destroy(gameObject);
        }
        if (other.CompareTag("Pared"))
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
         if (jugador != null)
        {
            // Aquí puedes ajustar la velocidad según el estado del jugador
            // Por ejemplo, si el jugador está moviéndose, podrías reducir la velocidad del enemigo
            float velocidadNormal = 10f; // Velocidad normal del enemigo
            float velocidadReducida = 5f; // Velocidad reducida cuando el jugador se mueve

            Movimiento movimiento = jugador.GetComponent<Movimiento>();
            if (movimiento != null && movimiento.estaDeslizando)
            {
                velocidad = velocidadReducida;
            }
            if (movimiento !=null && !movimiento.estaDeslizando)
            {
                velocidad = velocidadNormal;
            }
        }
    }
}
