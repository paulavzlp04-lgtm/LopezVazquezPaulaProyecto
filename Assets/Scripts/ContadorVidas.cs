using TMPro;
using UnityEngine;

public class ContadorVidas : MonoBehaviour
{
    public static int vidas = 3;

    [SerializeField] TMP_Text texto;

    void Start()
    {
        ContadorFrutas.frutasAlEmpezarNivel = ContadorFrutas.frutas;
        texto.text = vidas.ToString();
    }
}