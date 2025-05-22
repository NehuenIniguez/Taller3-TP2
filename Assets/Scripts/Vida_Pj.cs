using UnityEngine;

public class Vida_Pj : MonoBehaviour
{
    // script simple para manejar la vida, el daño se manejará desde los enemigos :)
    [SerializeField] private int vidaMaxima = 3;
    private int vidaActual;
    void Start()
    {
        vidaActual = vidaMaxima;
    }


    public void TomarDaño(int danio)
    {
        vidaActual -= danio;
        if (vidaActual <= 0)
        {
            Destroy(gameObject);
        }
    }
}
