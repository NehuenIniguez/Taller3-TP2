using TMPro;
using UnityEngine;

public class PuntoTutorial : MonoBehaviour
{
     public int puntos;
    private TextMeshProUGUI TMPro;
    private GameObject personaje;
    void Start()
    {
        TMPro = GetComponent<TextMeshProUGUI>();
        personaje = GameObject.FindGameObjectWithTag("Personaje");
    }

    public void SumaPuntos(int cantidad)
    {
        if (personaje.GetComponent<Vida_Pj>().muerto == false)
        {
            puntos += cantidad;
            TMPro.text = puntos.ToString();
        }
        if (personaje.GetComponent<Vida_Pj>().muerto == true)
        {
            puntos = 0;
        }
    }
}
