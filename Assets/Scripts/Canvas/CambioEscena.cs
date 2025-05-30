using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public GameObject Opciones;
    
    /*void Start()
    {
        GameObject puntos = GameObject.FindWithTag("Puntos");
    }*/

    public void volverMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Selector()
    {
        SceneManager.LoadScene("LevelSelector");
        Time.timeScale = 1f;
     }
    public void LevelUno()
    {
        SceneManager.LoadScene("SampleScene"); // O el nombre que tenga tu escena
    }
    public void LevelDos()
    {
        SceneManager.LoadScene("Level2"); // O el nombre que tenga tu escena
    }
    public void LevelTres()
    {
        SceneManager.LoadScene("Level3"); // O el nombre que tenga tu escena
    }
    public void LevelCuatro()
    {
        SceneManager.LoadScene("Level4"); // O el nombre que tenga tu escena
    }
    public void LevelCinco()
    {
        SceneManager.LoadScene("Level5"); // O el nombre que tenga tu escena
    }
        public void LevelSeis()
    { 
        SceneManager.LoadScene("Level6"); // O el nombre que tenga tu escena
    }
}
