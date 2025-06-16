using UnityEngine;

public class InactividadDetector : MonoBehaviour
{
    public float tiempoInactivo = 0f;
    public float tiempoLimite = 3f; // segundos
    public bool inactivo = false;

    private Vector2 ultimaPos;
    
    void Start()
    {
        ultimaPos = transform.position;
    }

    void Update()
    {
        if ((Vector2)transform.position == ultimaPos)
        {
            tiempoInactivo += Time.deltaTime;
            if (tiempoInactivo >= tiempoLimite)
                inactivo = true;
        }
        else
        {
            tiempoInactivo = 0f;
            inactivo = false;
            ultimaPos = transform.position;
        }
    }
}
