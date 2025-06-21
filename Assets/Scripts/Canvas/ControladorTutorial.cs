using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Unity.Cinemachine;
using TMPro;

public class ControladorTutorial : MonoBehaviour
{
    public GameObject[] textos;
    public Image imagenFondo;
    private int indice = 0;
    private bool puedeAvanzar = true;
    [SerializeField] private CinemachineCamera cinemachine;
    private TextMeshProUGUI textoActualUI;
    private string textoCompleto;
    private Coroutine escribiendoTexto;

    void Start()
    {
        Time.timeScale = 0;

        imagenFondo.enabled = true;

        for (int i = 0; i < textos.Length; i++)
        {
            textos[i].SetActive(i == 0);
        }

        if (textos.Length > 0)
        {
            textoActualUI = textos[0].GetComponentInChildren<TextMeshProUGUI>();
            if (textoActualUI != null)
            {
                textoCompleto = textoActualUI.text;
                textoActualUI.text = "";
                escribiendoTexto = StartCoroutine(MostrarCaracter());
            }
        }
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            AvanzarTexto();
        }
#else
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && puedeAvanzar)
        {
            puedeAvanzar = false;
            AvanzarTexto();
        }

        if (Input.touchCount == 0)
        {
            puedeAvanzar = true;
        }
#endif
    }

    void AvanzarTexto()
    {
        if (escribiendoTexto != null)
        {
            StopCoroutine(escribiendoTexto);
            escribiendoTexto = null;
            textoActualUI.text = textoCompleto;
            return;
        }

        textos[indice].SetActive(false);
        indice++;

        if (indice < textos.Length)
        {
            textos[indice].SetActive(true);

            textoActualUI = textos[indice].GetComponentInChildren<TextMeshProUGUI>();
            if (textoActualUI != null)
            {
                textoCompleto = textoActualUI.text;
                textoActualUI.text = "";
                escribiendoTexto = StartCoroutine(MostrarCaracter());
            }
            else
            {
                Debug.LogError("No se encontró componente TextMeshProUGUI en: " + textos[indice].name);
            }
        }
        else
        {
            if (cinemachine != null)
            {
                cinemachine.Lens.OrthographicSize = 18f;
            }

            Time.timeScale = 1;
            imagenFondo.enabled = false;
            Destroy(gameObject);
        }
    }

    IEnumerator MostrarCaracter()
    {
        foreach (char c in textoCompleto)
        {
            textoActualUI.text += c;
            yield return new WaitForSecondsRealtime(0.02f); // Usa WaitForSecondsRealtime porque Time.timeScale está en 0
        }

        escribiendoTexto = null;
    }
}
