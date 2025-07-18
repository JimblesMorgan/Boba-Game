using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 offset;
    Vector3 newpos;

    public GameObject player;

     void Start()
    {
        offset = player.transform.position - transform.position;

    }

     void Update()
    {
        transform.position = player.transform.position - offset; 
    }
}
