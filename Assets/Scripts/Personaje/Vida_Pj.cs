using UnityEngine;

public class Vida_Pj : MonoBehaviour
{
    // script simple para manejar la vida, el daño se manejará desde los enemigos :)
    [SerializeField] private float vidaMaxima = 3;
    private float vidaActual;
    public GameObject panelMuerte;
    [SerializeField] private Transform spawn;
    
    void Start()
    {
        vidaActual = vidaMaxima;
    }


    public void TomarDanio(float danio)
    {
        vidaActual -= danio;
        transform.position = spawn.position;
        if (vidaActual <= 0)
        {
            Destroy(gameObject);
            panelMuerte.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
