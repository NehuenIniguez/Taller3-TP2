using UnityEngine;

public class Opciones : MonoBehaviour
{
    public GameObject panelOpciones;
    public void Salir()
    {
        Application.Quit();
    }
    public void Settings()
    {
        panelOpciones.SetActive(true);
    }
    public void cerrarOpciones()
    {
        panelOpciones.SetActive(false);
    }
    public void Volumen(float volumen)
    {
        AudioListener.volume = volumen;
     }
}
