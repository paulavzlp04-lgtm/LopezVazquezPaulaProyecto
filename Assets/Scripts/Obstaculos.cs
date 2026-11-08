using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstaculos : MonoBehaviour
{
    [SerializeField] AudioClip sonidoMorir;
    Animator animator;
    GameObject ninja;

    private void OnCollisionEnter2D(Collision2D ninja)
    {
        if (ninja.gameObject.CompareTag("Player"))
        {
            this.ninja = ninja.gameObject;
            animator = ninja.gameObject.GetComponent<Animator>();
            ninja.gameObject.GetComponent<MovimientoJugador>().SonarMuerte();
            ninja.gameObject.GetComponent<MovimientoJugador>().enabled = false;
            animator.Play("Morir");
            Invoke("Morir", 2f);
            Invoke("Reiniciar", 4f);
        }


    }

    void Reiniciar()
    {
        ContadorVidas.vidas--;
        ContadorFrutas.frutas = ContadorFrutas.frutasAlEmpezarNivel;

        if (ContadorVidas.vidas <= 0)
        {
            ContadorVidas.vidas = 3;
            SceneManager.LoadScene("Fin");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Morir()
    {
        Destroy(ninja);

    }
}
