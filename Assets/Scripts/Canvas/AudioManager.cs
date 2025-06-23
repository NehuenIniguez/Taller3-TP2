using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instancia;

    [Range(0f, 1f)] public float volumenGeneral = 1f;

    void Awake()
    {
        if (instancia != null && instancia != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);

            // 👇 Suscribirse al evento de cambio de escena
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    void OnDestroy()
    {
        // 👇 Desuscribirse cuando se destruye (importante para evitar errores si se recarga la escena)
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        AplicarVolumenAGrupo();
    }

    // ✅ Esto se ejecuta automáticamente al cargar cualquier escena
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AplicarVolumenAGrupo();
    }

    public void SetVolumen(float nuevoVolumen)
    {
        volumenGeneral = Mathf.Clamp01(nuevoVolumen);
        AplicarVolumenAGrupo();
    }

    void AplicarVolumenAGrupo()
    {
        AudioSource[] todosLosAudios = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
        foreach (AudioSource a in todosLosAudios)
        {
            a.volume = volumenGeneral;
        }
    }

    public void ActualizarVolumenes()
    {
        AplicarVolumenAGrupo();
    }
}
