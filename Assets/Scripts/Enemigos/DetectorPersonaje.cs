using UnityEngine;
using UnityEngine.AI;
public class DetectorPersonaje : MonoBehaviour
{
    private NavMeshAgent agent;
    private float velocidad = 3f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = velocidad;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Personaje"))
        {
            Vector3 targetPosition = other.transform.position;
            agent.SetDestination(targetPosition);
            agent.speed += velocidad; 
        }
        
    }
}
