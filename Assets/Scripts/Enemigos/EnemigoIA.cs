using UnityEngine;
using UnityEngine.AI;

public class EnemigoIA : MonoBehaviour
{
    public float rangoMovimiento = 10f;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        MoverANuevaPosicion();
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        { 
            MoverANuevaPosicion();
        }
    }

    void MoverANuevaPosicion()
    {
        Vector2 randomDirection = Random.insideUnitCircle * rangoMovimiento;
        Vector3 destino = new Vector3(transform.position.x + randomDirection.x, transform.position.y + randomDirection.y, 0);

        NavMeshHit hit;
        if (NavMesh.SamplePosition(destino, out hit, 1.0f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Personaje"))
        {
            collision.gameObject.GetComponent<Vida_Pj>().TomarDanio(3);
        }
    }
}
