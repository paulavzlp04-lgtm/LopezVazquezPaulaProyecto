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
        if (ninja == null) return;

        transform.position = new Vector3(
            ninja.transform.position.x,
            ninja.transform.position.y,
            transform.position.z
        );
    }
}
