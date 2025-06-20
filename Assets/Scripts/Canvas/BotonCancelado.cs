using UnityEngine;
using UnityEngine.UI;

public class BotonCancelado : MonoBehaviour
{
    [SerializeField] public int puntosNecesarios; // Cambialo según el botón
    private Button boton;
    

    void Start()
    {
        
        boton = GetComponent<Button>();

        if (ControladorPuntos.instancia != null)
        {
            boton.colors = new ColorBlock
                {
                    normalColor = Color.gray, // Color normal del botón
                    highlightedColor = Color.gray, // Color al pasar el mouse
                    pressedColor = Color.gray, // Color al presionar
                    selectedColor = Color.gray, // Color seleccionado
                    disabledColor = Color.gray, // Color deshabilitado
                    colorMultiplier = 1f,
                    fadeDuration = 0.1f
                };
            if (ControladorPuntos.instancia.puntosTotales >= puntosNecesarios)
            {
                boton.interactable = true; // Se puede clickear
                boton.colors = new ColorBlock
                {
                    normalColor = Color.white, // Color normal del botón
                    highlightedColor = Color.yellow, // Color al pasar el mouse
                    pressedColor = Color.gray, // Color al presionar
                    selectedColor = Color.white, // Color seleccionado
                    disabledColor = Color.gray, // Color deshabilitado
                    colorMultiplier = 1f,
                    fadeDuration = 0.1f
                };
            }
            else
            {
                boton.interactable = false; // Está bloqueado
            }
        }
        else
        {
            Debug.LogWarning("ControladorPuntos no encontrado.");
        }
    }
}
