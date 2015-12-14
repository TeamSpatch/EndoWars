using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            Transform enemy = transform.parent;
            enemy.parent = other.transform;
            enemy.gameObject.GetComponent<Enemy>().isCaptured = true;
            enemy.gameObject.GetComponent<Collider2D>().isTrigger = true;
            Rigidbody2D rigid = enemy.gameObject.GetComponent<Rigidbody2D>();
            rigid.isKinematic = true;
            rigid.velocity = Vector2.zero;
            rigid.angularVelocity = 0;
            Canon canon = enemy.FindChild("Canon").GetComponent<Canon>();
            canon.color = enemy.gameObject.GetComponent<Enemy>().color;
            canon.enabled = true;
            other.gameObject.GetComponent<PlayerStatus>().Hook();
            StartCoroutine(Animation(enemy));
        }
    }

    IEnumerator Animation(Transform enemy)
    {
        Animator animator = enemy.gameObject.GetComponent<Animator>();
        animator.SetBool("Grabbed", true);
        yield return new WaitForSeconds(0.733f);
        animator.enabled = false;
    }
}
