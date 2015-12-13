using UnityEngine;
using System.Collections;

public class PlayerRotation : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        if (Input.GetButton("Move") || Input.GetButton("Turn")) {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;
            Vector3 direction = mousePosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.fixedDeltaTime);
        }
    }
}
