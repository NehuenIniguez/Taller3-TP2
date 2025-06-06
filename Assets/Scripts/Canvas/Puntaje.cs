using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour
{
    private int puntos = 0;
    private TextMeshProUGUI TMPro;
    void Start()
    {
        TMPro = GetComponent<TextMeshProUGUI>();
    }

    public void SumaPuntos(int cantidad)
    {
        puntos += cantidad;
        TMPro.text = puntos.ToString();    
    }
}
