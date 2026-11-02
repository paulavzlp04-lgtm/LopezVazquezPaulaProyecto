using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemigo : MonoBehaviour
{
    // Cuánto rebota Ninja hacia arriba al pisar al bicho.
    [SerializeField] float rebote = 6f;

    Animator animator;
    GameObject ninja;
    bool ninjaMuerto;  
     // Evita que se repita la muerte si vuelve a chocar.

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        if (ninjaMuerto) return;

        // Si Ninja cae desde arriba, muere el bicho.
        if (other.GetContact(0).normal.y < -0.5f)
        {
            // Ninja rebota hacia arriba.
            other.gameObject.GetComponent<Rigidbody2D>().linearVelocityY = rebote;

            // El bicho desaparece.
            Destroy(gameObject);
        }
        else
        {
            // Si lo toca de lado, muere Ninja (igual que en Obstaculos).
            ninjaMuerto = true;
            ninja = other.gameObject;
            animator = ninja.GetComponent<Animator>();

            ninja.GetComponent<MovimientoJugador>().enabled = false;
            ninja.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            animator.Play("Morir");

            Invoke("Morir", 2f);
            Invoke("Reiniciar", 4f);
        }
    }

    void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Morir()
    {
        Destroy(ninja);
    }
}