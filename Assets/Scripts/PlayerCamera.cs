using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
    GameObject player;
    Vector3 velocity;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        Vector3 target = player.transform.position;
        target.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, 0.3f);
    }
}
