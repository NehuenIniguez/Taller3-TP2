using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
   public void CambiarEscena()
    {
        SceneManager.LoadScene("SampleScene"); // O el nombre que tenga tu escena
    }
}
