using UnityEngine;
using UnityEngine.AI;

public class EnemigoIA : MonoBehaviour
{
    [SerializeField] Transform player;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        agent.SetDestination(player.position);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Personaje"))
        {
            collision.gameObject.GetComponent<Vida_Pj>().TomarDanio(3);
        }
    }
}
