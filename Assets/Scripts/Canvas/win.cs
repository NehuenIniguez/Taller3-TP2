using UnityEngine;

public class win : MonoBehaviour
{
    public GameObject panelVictoria;
    public bool gane = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Personaje"))
        {
            panelVictoria.SetActive(true);
            Time.timeScale = 0;
            gane = true;

             ControladorPuntos.instancia.AlmacenarPuntos(); 
        }
    }
}
