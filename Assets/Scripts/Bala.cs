using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float danio = 1f;
    [SerializeField] private float tiempoDeVida = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }
}
