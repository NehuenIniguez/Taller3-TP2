using System.Collections;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    /*basicamente el escript maneja el movimiento del personaje, al detectar un swipe en la pantalla devuelve un valor, 
    dicho valor multiplicado por el tiempo y la direccion del vector 3 nos da como resultado el movimiento, 
    pero al tocar la pantalla podemos frenar dicho movimiento
    Le agrego que cuando el personaje se mueva la escena (en realidad los enemigos) se hagan mas lentos*/
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private float velocidadDeslizamiento = 25f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 direccionActual = Vector2.zero;
    public bool estaDeslizando = false;

    [SerializeField] private ParticleSystem particle;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;

                if (estaDeslizando)
                {
                    CancelarMovimiento();
                    return;
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;
                Vector2 swipe = endTouchPosition - startTouchPosition;

                if (swipe.magnitude > 50f)
                {
                    swipe.Normalize();
                    Vector2 nuevaDireccion = CalcularDireccion(swipe);
                    particle.Play();

                    if (nuevaDireccion != Vector2.zero)
                    {
                        StartCoroutine(AnimacionTransicionYDeslizamiento(nuevaDireccion));
                    }
                }
            }
        }
    }

    IEnumerator AnimacionTransicionYDeslizamiento(Vector2 direccion)
    {
        animator.SetTrigger("Transicion");

        yield return new WaitForSeconds(0.2f); // tiempo para la transición

        direccionActual = direccion;
        estaDeslizando = true;
        ActivarAnimacionDireccion(direccion);
    }

    void FixedUpdate()
    {
        if (estaDeslizando)
        {
            Vector2 nuevaPos = rb.position + direccionActual * velocidadDeslizamiento * Time.fixedDeltaTime;
            rb.MovePosition(nuevaPos);
        }
    }

    void CancelarMovimiento()
    {
        estaDeslizando = false;
        direccionActual = Vector2.zero;
        animator.SetTrigger("Idle");
    }

    Vector2 CalcularDireccion(Vector2 swipe)
    {
        if (Vector2.Dot(swipe, Vector2.up) > 0.7f)
            return Vector2.up;
        else if (Vector2.Dot(swipe, Vector2.down) > 0.7f)
            return Vector2.down;
        else if (Vector2.Dot(swipe, Vector2.left) > 0.7f)
            return Vector2.left;
        else if (Vector2.Dot(swipe, Vector2.right) > 0.7f)
            return Vector2.right;

        return Vector2.zero;
    }

    void ActivarAnimacionDireccion(Vector2 direction)
    {
        if (Vector2.Dot(direction, Vector2.right) > 0.9f)
            animator.SetTrigger("Derecha");
        else if (Vector2.Dot(direction, Vector2.left) > 0.9f)
            animator.SetTrigger("Izquierda");
        else if (Vector2.Dot(direction, Vector2.up) > 0.9f)
            animator.SetTrigger("Arriba");
        else if (Vector2.Dot(direction, Vector2.down) > 0.9f)
            animator.SetTrigger("Abajo");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CancelarMovimiento();
    }

}
