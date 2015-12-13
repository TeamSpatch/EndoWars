using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public enum Color
    {
        White,
        Red,
        Green,
    }

    public float speed;
    public Color color;
    public bool isFriendly;
    [HideInInspector]
    public Vector3 move;


    void FixedUpdate()
    {
        transform.parent.Translate(move * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isFriendly) {
            if (other.gameObject.tag == "Enemy") {
                Enemy enemy = other.gameObject.GetComponent<Enemy>();
                if (!enemy.isCaptured && !enemy.isDead && (color == Color.White || enemy.color == color)) {
                    enemy.Die();
                    return;
                }
            } else if (other.gameObject.tag == "Elite") {
                Elite elite = other.gameObject.GetComponent<Elite>();
                if (!elite.isDead && color == Color.White) {
                    elite.Die();
                    Destroy(transform.parent.gameObject);
                    return;
                }
            }
        } else {
            if (other.gameObject.tag == "Player") {
                other.gameObject.GetComponent<PlayerStatus>().Damage();
                Destroy(transform.parent.gameObject);
                return;
            }
        }
        if (other.gameObject.tag == "Wall") {
            Destroy(transform.parent.gameObject);
            return;
        }
    }
}
