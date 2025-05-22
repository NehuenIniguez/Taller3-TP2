using UnityEngine;

public class Movimiento : MonoBehaviour
{
    /*basicamente el escript maneja el movimiento del personaje, al detectar un swipe en la pantalla devuelve un valor, 
    dicho valor multiplicado por el tiempo y la direccion del vector 3 nos da como resultado el movimiento, 
    pero al tocar la pantalla podemos frenar dicho movimiento*/
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    public float movimientoDistancia = 1500f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Al tocar la pantalla
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }

            // Al levantar el dedo
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;
            }
        }
        
    }
    void FixedUpdate()
    {
        Vector2 swipe = endTouchPosition - startTouchPosition;

        if (swipe.magnitude < 50f) return;


        swipe.Normalize();

        if (Vector2.Dot(swipe, Vector2.up) > 0.7f)
        {
            Debug.Log("Swipe hacia arriba");
            transform.position += Vector3.up * movimientoDistancia * Time.fixedDeltaTime;
        }
        else if (Vector2.Dot(swipe, Vector2.down) > 0.7f)
        {
            Debug.Log("Swipe hacia abajo");
            transform.position += Vector3.down * movimientoDistancia * Time.fixedDeltaTime;
        }
        else if (Vector2.Dot(swipe, Vector2.left) > 0.7f)
        {
            Debug.Log("Swipe a la izquierda");
            transform.position += Vector3.left * movimientoDistancia * Time.fixedDeltaTime;
        }
        else if (Vector2.Dot(swipe, Vector2.right) > 0.7f)
        {
            Debug.Log("Swipe a la derecha");
            transform.position += Vector3.right * movimientoDistancia * Time.fixedDeltaTime;
        }
    }


}
