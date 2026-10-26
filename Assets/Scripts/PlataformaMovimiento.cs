using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlataformaMovimiento : MonoBehaviour
{
    float velocidad = 2f;
    int direcion = 1;
    void Update()
    {
     transform.position += new Vector3(direcion * velocidad * Time.deltaTime,0,0);

        if (transform.position.x >= 31)
        {
            direcion = -1;
        }

           if (transform.position.x <= 23)
        {
            direcion = 1;
        }
    }
}
