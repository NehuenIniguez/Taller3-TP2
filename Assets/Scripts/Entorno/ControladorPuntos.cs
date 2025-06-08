using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorPuntos : MonoBehaviour
{
    public static ControladorPuntos instancia;

    private GameObject win;
    private GameObject puntos;
    public int puntosTotales;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // <- se suscribe a cambios de escena
        }
        else
        {
            Destroy(gameObject); // Evita duplicados si volvés al menú
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        win = GameObject.FindGameObjectWithTag("Win");
        if (win == null)
        {
            Debug.LogWarning("No se encontró el objeto 'Win' en esta escena.");
        }

        var puntosComp = FindAnyObjectByType<Puntaje>();
        if (puntosComp == null)
        {
            Debug.LogWarning("No se encontró el componente 'Puntos' en esta escena.");
        }
        else
        {
            puntos = puntosComp.gameObject;
        }
    }

    public void AlmacenarPuntos()
    {
        if (win.GetComponent<win>().gane == true)
        {
            puntosTotales += puntos.GetComponent<Puntaje>().puntos;
        }
        else
        {
            puntosTotales = 0;
        }
    }

    public void Update()
    {
        Debug.Log("Puntos Totales: " + puntosTotales); 
     }
}
