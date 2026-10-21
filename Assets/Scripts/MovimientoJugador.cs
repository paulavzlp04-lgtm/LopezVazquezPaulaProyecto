using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    float velocidad = 3f;
    float velocidadSalto = 4f;
    Animator animator;
    InputAction move;
    InputAction jump;
    Rigidbody2D rgb;
     SpriteRenderer sprite;
    void Start()
    {
        jump = InputSystem.actions.FindAction("Jump");
        move = InputSystem.actions.FindAction("Move");
        // Coge el Rigidbody2D que tiene este mismo objeto.
        // Si el personaje no tiene Rigidbody2D, dará error.
        rgb = GetComponent<Rigidbody2D>();

        // animaciones
   
        animator = GetComponent<Animator>();

        //Sprite

         sprite = GetComponent<SpriteRenderer>();


    }
        // Para que se mueva y no se caiga: marcar Freeze Rotation Z en el Rigidbody2D
        // (Rigidbody2D > Constraints > Freeze Rotation Z).

        // UPDATE: Unity ejecuta esto una y otra vez, en cada fotograma.
        // Aquí revisamos qué teclas pulsa el jugador y movemos al personaje.

    void Update()
    {
       // Lee qué pulsa el jugador: x = -1 izquierda, 1 derecha, 0 nada.
        Vector2 movimiento = move.ReadValue<Vector2>();

        // Mueve al personaje de lado a lado.
        // Solo tocamos la X, así la gravedad (eje Y) sigue funcionando.
        rgb.linearVelocityX = movimiento.x * velocidad;

        // WasPressedThisFrame = "se acaba de pulsar ahora mismo".
        // Es mejor que IsPressed para saltar, porque IsPressed es verdadero
        // todo el rato que mantienes el botón y saltaría sin parar.
        if (jump.WasPressedThisFrame())
        {
            // Da velocidad hacia arriba (eje Y) al personaje.
            // La gravedad lo hará caer después sola.
            rgb.linearVelocityY = velocidadSalto;
        }


       //Que se mueva con el flip

         if (movimiento.x > 0)
        {
            sprite.flipX = false;
        }
        else if (movimiento.x < 0)
        {
            sprite.flipX = true;
        }


        // Animaciones

        // Si toca el suelo y no se mueve: quieto (0).
        if (movimiento.x == 0)
        {
            animator.SetInteger("estado", 0);
        }
        // Si toca el suelo y se mueve: correr (1).
        else
        {
            animator.SetInteger("estado", 1);
        }


    }
}

