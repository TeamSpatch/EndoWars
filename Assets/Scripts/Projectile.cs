using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public enum Color
    {
        White,
        Red,
        Green,
        Blue,
    }

    public float speed;
    public bool isFriendly;
    [HideInInspector]
    public Vector3 move;

    Color color;

    void FixedUpdate()
    {
        transform.Translate(move * speed * Time.fixedDeltaTime);
    }

    public void SetColor(Color color)
    {
        this.color = color;
        if (color == Color.Red) {
            GetComponent<SpriteRenderer>().color = UnityEngine.Color.red;
        } else if (color == Color.Green) {
            GetComponent<SpriteRenderer>().color = UnityEngine.Color.green;
        } else if (color == Color.Blue) {
            GetComponent<SpriteRenderer>().color = UnityEngine.Color.blue;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isFriendly) {
            if (other.gameObject.tag == "Enemy") {
                Enemy enemy = other.gameObject.GetComponent<Enemy>();
                if (!enemy.isDead && (color == Color.White || enemy.color == color)) {
                    enemy.Die();
                    Destroy(gameObject);
                }
            }
        } else {
            if (other.tag == "Player") {
                Debug.Log("PLAYER GOT HIT");
            }
        }
    }
}
