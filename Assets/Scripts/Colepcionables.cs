using Unity.VisualScripting;
using UnityEngine;

public class Colepcionables : MonoBehaviour
{
 private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.CompareTag("Player")){
            FindFirstObjectByType<ContadorFrutas>().SumarFruta();
             Destroy(gameObject);
        }
       
    }

}
