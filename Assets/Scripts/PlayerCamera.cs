using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
    public float dampSmooth;
    public float offsetFactor;

    Transform player;
    Rigidbody2D rigid;
    Vector3 velocity;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigid = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 target = player.position + player.up.normalized * offsetFactor;
        target.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, dampSmooth * Time.fixedDeltaTime);
    }
}
