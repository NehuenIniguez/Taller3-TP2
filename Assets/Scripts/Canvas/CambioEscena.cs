using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public GameObject Opciones;

    public void volverMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
    public void Selector()
    {
        SceneManager.LoadScene("LevelSelector");
        Time.timeScale = 1f;
    }
    public void LevelUno()
    {
        SceneManager.LoadScene("SampleScene"); // O el nombre que tenga tu escena
        Time.timeScale = 1f;
    }
    public void LevelDos()
    {
        if (ControladorPuntos.instancia != null && ControladorPuntos.instancia.puntosTotales >= 36)
        {
            SceneManager.LoadScene("Level2"); // O el nombre que tenga tu escena
            Time.timeScale = 1f;
        }
    }
    public void LevelTres()
    {
        SceneManager.LoadScene("Level3"); // O el nombre que tenga tu escena
        Time.timeScale = 1f;
    }
    public void LevelCuatro()
    {
        SceneManager.LoadScene("Level4"); // O el nombre que tenga tu escena
        Time.timeScale = 1f;
    }
    public void LevelCinco()
    {
        SceneManager.LoadScene("Level5"); // O el nombre que tenga tu escena
        Time.timeScale = 1f;
    }
    public void LevelSeis()
    {
        SceneManager.LoadScene("Level6"); // O el nombre que tenga tu escena
        Time.timeScale = 1f;
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial"); // O el nombre que tenga tu escena
        Time.timeScale = 1f;
    }
}
