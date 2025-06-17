using UnityEngine;

public class MovimientoCircular : MonoBehaviour
{
    [Header("Movimiento Circular Cierra")]
    public Transform centro;
    private float velocidad = 180f;
    public float radio = 2f;
    private float angulo = 0f;
    private float direccion = 1f;
    public int danio = 2;
    private Transform jugadorTransform;

    void Start()
    {
        jugadorTransform = GameObject.FindWithTag("Personaje").transform;

    }
    void Update()
    {
        if (jugadorTransform != null)
        {
            // Aquí puedes ajustar la velocidad según el estado del jugador
            // Por ejemplo, si el jugador está moviéndose, podrías reducir la velocidad del enemigo
            float velocidadNormal = 180f; // Velocidad normal del enemigo
            float velocidadReducida = 90f; // Velocidad reducida cuando el jugador se mueve

            Movimiento movimiento = jugadorTransform.GetComponent<Movimiento>();
            if (movimiento != null && movimiento.estaDeslizando)
            {
                velocidad = velocidadReducida;
            }
            if (movimiento != null && !movimiento.estaDeslizando)
            {
                velocidad = velocidadNormal;
            }
        }
        angulo += direccion * velocidad * Time.deltaTime;
        float radianes = angulo * Mathf.Deg2Rad;
        Vector3 posicion = new Vector3(
            centro.position.x + Mathf.Cos(radianes) * radio,
            centro.position.y + Mathf.Sin(radianes) * radio,
            transform.position.z
        );
        transform.position = posicion;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Personaje"))
        {
            other.GetComponent<Vida_Pj>().TomarDanio(danio);
        }
    }
}
