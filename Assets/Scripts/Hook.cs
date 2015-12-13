using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            Transform enemy = transform.parent;
            Vector3 scale = enemy.localScale;
            enemy.parent = other.transform;
            enemy.localScale = scale;
            enemy.gameObject.GetComponent<Enemy>().isCaptured = true;
            enemy.gameObject.GetComponent<Collider2D>().isTrigger = true;
            Rigidbody2D rigid = enemy.gameObject.GetComponent<Rigidbody2D>();
            rigid.isKinematic = true;
            rigid.velocity = Vector2.zero;
            rigid.angularVelocity = 0;
            Canon canon = enemy.FindChild("Canon").GetComponent<Canon>();
            canon.color = enemy.gameObject.GetComponent<Enemy>().color;
            canon.enabled = true;
            ++other.gameObject.GetComponent<PlayerStatus>().blackness;
        }
    }
}
