using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Projectile.Color color;
    public float forceFactor;
    public float angularSpeed;
    public float cooldownDuration;
    [HideInInspector]
    public bool isDead { get; private set; }

    GameObject player;
    Rigidbody2D rigid;
    float cooldown;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigid = GetComponent<Rigidbody2D>();
        cooldown = 0f;
    }

    void FixedUpdate()
    {
        Vector3 target = player.transform.position;
        target.z = transform.position.z;
        Vector3 direction = target - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 45f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, angularSpeed * Time.fixedDeltaTime);
        if (cooldown > 0f) {
            cooldown -= Time.fixedDeltaTime;
        }
        if (cooldown <= 0f) {
            rigid.AddForce(forceFactor * (new Vector2(target.x, target.y) - new Vector2(transform.position.x, transform.position.y)).normalized);
            cooldown = cooldownDuration;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player") {
            // @TODO : monstre s'attache au héros
        }
    }

    public void Die()
    {
        if (!isDead) {
            isDead = true;
            Destroy(gameObject);
        }
    }
}
