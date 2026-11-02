using TMPro;
using UnityEngine;

public class ContadorFrutas : MonoBehaviour
{
    public static int frutas = 0;
    public TMP_Text texto;

    void Start()
    {
        texto.text = frutas.ToString();
    }
    public void SumarFruta()
    {
        frutas++;
        texto.text = frutas.ToString();
    }
}
