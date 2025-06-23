using UnityEngine;
using UnityEngine.UI;

public class ControlVolumen : MonoBehaviour
{
    public Slider sliderVolumen;

    void Start()
    {
        if (AudioManager.instancia != null)
            sliderVolumen.value = AudioManager.instancia.volumenGeneral;

        sliderVolumen.onValueChanged.AddListener(ActualizarVolumen);
    }

    void ActualizarVolumen(float valor)
    {
        if (AudioManager.instancia != null)
            AudioManager.instancia.SetVolumen(valor);
    }
}
