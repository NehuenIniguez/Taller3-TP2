using UnityEngine;

public class Recoloectables : MonoBehaviour
{
    public int puntos = 1;
    [SerializeField] private Puntaje puntaje;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Personaje"))
        {
            puntaje.SumaPuntos(puntos);
            Destroy(gameObject);
            
        }
    }
}
