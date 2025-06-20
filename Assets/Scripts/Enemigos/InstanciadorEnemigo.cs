using UnityEngine;

public class InstanciadorEnemigo : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public Transform spawnPoint;
    public InactividadDetector detector;

    private bool enemigoInstanciado = false;

    void Start()
    {
        detector = FindAnyObjectByType<InactividadDetector>();
        
    }
    void Update()
    {
        if (detector != null && detector.inactivo && !enemigoInstanciado)
        {
            Instantiate(enemigoPrefab, spawnPoint.position, Quaternion.identity);
            enemigoInstanciado = true;
        }
    }
}
