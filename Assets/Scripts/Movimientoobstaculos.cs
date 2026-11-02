using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlataformaMovimiento : MonoBehaviour
{   
     // Velocidad a la que anda.
    [SerializeField] float velocidad = 2f;

    // Cuánto se aleja hacia cada lado desde donde lo coloques.
    [SerializeField] float distancia = 3f;

    float limiteIzquierdo;
    float limiteDerecho;
    int direccion = 1;   // 1 = derecha, -1 = izquierda.

    SpriteRenderer sprite;

    void Start()
    {
        // Los límites se calculan desde donde pongas el objeto en la escena,
        // así funciona en cualquier sitio.
        limiteIzquierdo = transform.position.x - distancia;
        limiteDerecho = transform.position.x + distancia;

        // Si es una plataforma y no tiene sprite que girar, no pasa nada.
        sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {

       // Lo mueve en la dirección actual.
        transform.position += new Vector3(direccion * velocidad * Time.deltaTime, 0, 0);

        // Llega al extremo derecho: da la vuelta.
        if (transform.position.x >= limiteDerecho)
        {
            direccion = -1;
        }
        // Llega al extremo izquierdo: da la vuelta.
        else if (transform.position.x <= limiteIzquierdo)
        {
            direccion = 1;
        }

        // Gira el dibujo hacia donde anda (solo si tiene sprite).
        if (sprite != null)
        {
            sprite.flipX = direccion < 0;
        }
    }


        /*
     transform.position += new Vector3(direcion * velocidad * Time.deltaTime,0,0);

        if (transform.position.x >= 31)
        {
            direcion = -1;
        }

           if (transform.position.x <= 23)
        {
            direcion = 1;
        }
        */
    }
    


