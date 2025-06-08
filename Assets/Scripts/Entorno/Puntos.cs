using TMPro;
using UnityEngine;

public class Puntos : MonoBehaviour
{
    private TextMeshProUGUI textoPuntos;
    public int punt;
    void Start()
    {
        textoPuntos = FindAnyObjectByType<TextMeshProUGUI>();
        punt = int.Parse(textoPuntos.text);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Puntos: " + punt);
    }
}
