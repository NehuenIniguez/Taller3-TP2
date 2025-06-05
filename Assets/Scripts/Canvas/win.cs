using UnityEngine;

public class win : MonoBehaviour
{
    public GameObject panelVictoria;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Personaje"))
        {
            panelVictoria.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
