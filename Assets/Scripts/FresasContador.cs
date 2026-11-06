using TMPro;
using UnityEngine;

public class PantallaFinal : MonoBehaviour
{
  
    [SerializeField] TMP_Text texto;

    void Start()
    {
       
        texto.text = "¡Conseguiste " + ContadorFrutas.frutas + " frutas!";
    }
}