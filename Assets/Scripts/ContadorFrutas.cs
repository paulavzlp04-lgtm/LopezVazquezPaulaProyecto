using TMPro;
using UnityEngine;

public class ContadorFrutas : MonoBehaviour
{
    public int frutas = 0;
    public TMP_Text texto;

    public void SumarFruta()
    {
        frutas++;
        texto.text = frutas.ToString();
    }
}
