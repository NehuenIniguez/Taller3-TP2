using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float danio = 1;
    [SerializeField] private float tiempoDeVida = 2f;
    void Start()
    {
        GameObject jugador = GameObject.FindWithTag("Personaje");
       
        //jugador.GetComponent<Vida_Pj>().TomarDanio(danio);
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
    }
}
