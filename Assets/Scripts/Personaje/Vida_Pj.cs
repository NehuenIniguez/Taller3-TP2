using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Vida_Pj : MonoBehaviour
{
    // script simple para manejar la vida, el daño se manejará desde los enemigos :)
    [SerializeField] private float vidaMaxima = 3;
    [SerializeField] private Image[] vida; // ← arrastrá las dos medallas desde el Canvas
    private float vidaActual;
    public GameObject panelMuerte;
    [SerializeField] private Transform spawn;
    public bool muerto = false;
    private AudioSource audioSource;
    [ SerializeField] public AudioClip sonidoMuerte;

    void Start()
    {
        vidaActual = vidaMaxima;
        audioSource = GetComponent<AudioSource>();
    }


    public void TomarDanio(float danio)
    {
        vidaActual -= danio;
        ActualizarVida();
        transform.position = spawn.position;
        if (vidaActual <= 0)
        {
            StartCoroutine(SonidoMuerte());
        }
    }
    private void ActualizarVida()
    {
        for (int i = 0; i < vida.Length; i++)
        {
            if (i < vidaActual)
            {
                vida[i].enabled = true;
            }
            else
            {
                vida[i].enabled = false;
            }
        }
    }

    private IEnumerator SonidoMuerte()
    {
        Time.timeScale = 0;
        audioSource.PlayOneShot(sonidoMuerte);
       
        yield return new WaitForSecondsRealtime(sonidoMuerte.length);
        
        Destroy(gameObject);
        panelMuerte.SetActive(true);
        
        muerto = true;
    }
}
