using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioJuego : MonoBehaviour
{

 public void Jugar()
    {
        SceneManager.LoadScene("Nivel1");
    }

}
