using UnityEngine;

public class Movimiento : MonoBehaviour
{
    /*basicamente el escript maneja el movimiento del personaje, al detectar un swipe en la pantalla devuelve un valor, 
    dicho valor multiplicado por el tiempo y la direccion del vector 3 nos da como resultado el movimiento, 
    pero al tocar la pantalla podemos frenar dicho movimiento
    Le agrego que cuando el personaje se mueva la escena (en realidad los enemigos) se hagan mas lentos*/
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    public float movimientoDistancia = 5f; // Usá una unidad razonable, no 1500f
    private Rigidbody2D rb;
    public bool estaMoviendo = false; // ← flag para enemigos
    public float duracionMovimiento = 0.3f; // cuanto tiempo "dura" el swipe
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
       
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                startTouchPosition = touch.position;
            else if (touch.phase == TouchPhase.Ended)
                endTouchPosition = touch.position;
        }
    }

    void FixedUpdate()
    {
        Vector2 swipe = endTouchPosition - startTouchPosition;

        if (swipe.magnitude < 50f) return;

        swipe.Normalize();
        Vector2 direction = Vector2.zero;

        if (Vector2.Dot(swipe, Vector2.up) > 0.7f)
            direction = Vector2.up;
        else if (Vector2.Dot(swipe, Vector2.down) > 0.7f)
            direction = Vector2.down;
        else if (Vector2.Dot(swipe, Vector2.left) > 0.7f)
            direction = Vector2.left;
        else if (Vector2.Dot(swipe, Vector2.right) > 0.7f)
            direction = Vector2.right;

        if (direction != Vector2.zero)
        {
            Vector2 nuevaPosicion = rb.position + direction * movimientoDistancia * Time.fixedDeltaTime;
            rb.MovePosition(nuevaPosicion);

            // Activo el flag para que los enemigos se muevan más lento
            estaMoviendo = true;
            CancelInvoke(nameof(DetenerMovimiento));
            Invoke(nameof(DetenerMovimiento), duracionMovimiento);
        }

    }
    void DetenerMovimiento()
    {
        estaMoviendo = false;
    }


}
