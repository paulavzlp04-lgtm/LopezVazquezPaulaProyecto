using UnityEngine;
using UnityEngine.SceneManagement;   // Necesario para cambiar de escena.

public class Meta : MonoBehaviour
{
    // Unity llama a esta función solo, cuando algo entra en la meta.
    // (Requiere un Collider2D con "Is Trigger" marcado.)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Solo seguimos si lo que ha tocado la meta es el jugador.
        // Si lo toca un enemigo o una moneda, no pasa nada.
        if (collision.gameObject.CompareTag("Player"))
        {
            // Guarda el número de la escena en la que estamos.
            // La primera escena es la 0, la siguiente la 1, y así.
            int indiceactual = SceneManager.GetActiveScene().buildIndex;

            // sceneCountInBuildSettings = cuántas escenas hay en total.
            // Se resta 1 porque se empieza a contar desde 0:
            // con 3 escenas, la última es la número 2.
            // Pregunta: "¿hay alguna escena después de esta?"
            if (indiceactual < SceneManager.sceneCountInBuildSettings - 1)
            {
                // Sí hay: carga la siguiente (la actual + 1).
                SceneManager.LoadScene(indiceactual + 1);
            }
            else
            {
                // No hay más: es el último nivel, así que cierra el juego.
                // OJO: dentro del editor de Unity no hace nada,
                // solo funciona en el juego ya exportado.
                Application.Quit();
            }
        }
    }
}