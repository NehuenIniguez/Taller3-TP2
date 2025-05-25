using UnityEngine;

public class Opciones : MonoBehaviour
{
    public GameObject panelOpciones;
    public bool Pausa = false;
    public void Salir()
    {
        Application.Quit();
    }
    public void Settings()
    {
        if (!Pausa)
        {
            panelOpciones.SetActive(true);
            Time.timeScale = 0;
            Pausa = true;
        }
    }
    public void cerrarOpciones()
    {
        if (Pausa)
        {
            panelOpciones.SetActive(false);
            Time.timeScale = 1;
            Pausa = false;
        }
    }
    public void Volumen(float volumen)
    {
        AudioListener.volume = volumen;
    }
    
}
