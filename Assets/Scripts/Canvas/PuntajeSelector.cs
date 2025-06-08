using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PuntajeSelector : MonoBehaviour
{
    private ControladorPuntos puntos;
    private TextMeshProUGUI TMPro;
    void Start()
    {
        TMPro = GetComponent<TextMeshProUGUI>();
        puntos = FindAnyObjectByType<ControladorPuntos>();
    }

  public void ActualizarPuntos()
    {
        if (puntos != null)
        {
            TMPro.text = puntos.puntosTotales.ToString();
        }
        else
        {
            Debug.LogError("ControladorPuntos no encontrado. Asegúrate de que exista en la escena.");
        }
    }
}
