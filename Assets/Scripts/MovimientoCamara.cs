using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    [SerializeField]
    GameObject ninja;
    void Start()
    {
        
    }

    void Update()
    {
          transform.position = new Vector3(
            ninja.transform.position.x,
            ninja.transform.position.y,
            transform.position.z
        );
    }
}
