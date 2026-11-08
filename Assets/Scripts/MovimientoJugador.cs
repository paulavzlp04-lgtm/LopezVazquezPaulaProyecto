using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MovimientoJugador : MonoBehaviour
{
    float velocidad = 5f;
    float velocidadSalto = 6f;
    Animator animator;
    InputAction move;
    InputAction jump;
    Rigidbody2D rgb;
    SpriteRenderer sprite;
    [SerializeField] LayerMask suelo;
    CapsuleCollider2D col;
    [SerializeField] AudioClip sonidoSalto;
    [SerializeField] AudioSource audioPasos;
    [SerializeField] AudioClip sonidoMorir;
    AudioSource audioSource;
    void Start()
    {
        jump = InputSystem.actions.FindAction("Jump");
        move = InputSystem.actions.FindAction("Move");
        audioSource = GetComponent<AudioSource>();
        // Coge el Rigidbody2D que tiene este mismo objeto.
        // Si el personaje no tiene Rigidbody2D, dará error.
        rgb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();

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
        if (jump.WasPressedThisFrame() && Estatocandosuelo())
        {
            // Da velocidad hacia arriba (eje Y) al personaje.
            // La gravedad lo hará caer después sola.
            rgb.linearVelocityY = velocidadSalto;
            audioSource.PlayOneShot(sonidoSalto);
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

         // Si NO toca el suelo, está en el aire.
        if (!Estatocandosuelo())
        {
            // Subiendo: saltar (2).
            if (rgb.linearVelocityY > 0.1f)
            {
                animator.SetInteger("estado", 2);
            }
            // Bajando: caer (3).
            else
            {
                animator.SetInteger("estado", 3);
            }
        }

        //audio andar

        // Pasos: suenan solo si se mueve y está en el suelo
        bool andando = movimiento.x != 0 && Estatocandosuelo();
        if (andando && !audioPasos.isPlaying)
        {
            audioPasos.Play();
        }
        else if (!andando && audioPasos.isPlaying)
        {
            audioPasos.Stop();
        }



    }


    public void SonarMuerte()
    {
        audioPasos.Stop();
        AudioSource.PlayClipAtPoint(sonidoMorir, transform.position);
    }

    bool Estatocandosuelo()
    {
        return Physics2D.BoxCast
        (col.bounds.center,
         col.bounds.size,
        0f,
        Vector2.down,
       .1f,
       suelo);

    }


}


