using Unity.VisualScripting;
using UnityEngine;

public class ControladorPuntos : MonoBehaviour
{

    public static ControladorPuntos instancia;
    private GameObject win;
    private GameObject puntos;
    public int puntosTotales ;
    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    void Start()
    {
        win = GameObject.FindGameObjectWithTag("Win");
        if (win == null)
        {
            Debug.LogError("No se encontró el objeto con la etiqueta 'Win'. Asegúrate de que exista en la escena.");
            return;
        }
        puntos = FindAnyObjectByType<Puntos>().gameObject;
        if (puntos == null)
        {
            Debug.LogError("No se encontró el objeto con el componente 'Puntos'. Asegúrate de que exista en la escena.");
            return;
        }
    }

    public void AlmacenarPuntos()
    {
        if (win.GetComponent<win>().gane == true)
        {
            puntosTotales += puntos.GetComponent<Puntos>().punt;

        }
        else
        {
            puntosTotales = 0;
        }
        Debug.Log("puntos totales:" + puntosTotales);
    }

}
