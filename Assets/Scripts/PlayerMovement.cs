using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float forceFactor;
    public float cooldownDuration;

    Rigidbody2D rigid;
    float cooldown;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        cooldown = 0f;
    }

    void FixedUpdate()
    {
        if (cooldown <= 0f) {
            if (Input.GetButton("Move")) {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = transform.position.z;
                float distance = Vector3.Distance(mousePosition, transform.position);
                rigid.AddForce(distance * forceFactor * (new Vector2(mousePosition.x, mousePosition.y) - new Vector2(transform.position.x, transform.position.y)).normalized);
                cooldown = cooldownDuration;
            }
        } else {
            cooldown -= Time.fixedDeltaTime;
        }
    }
}
