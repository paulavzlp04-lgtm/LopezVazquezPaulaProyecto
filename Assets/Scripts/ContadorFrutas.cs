using TMPro;
using UnityEngine;

public class ContadorFrutas : MonoBehaviour
{
    public static int frutas;
    public static int frutasAlEmpezarNivel;
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
