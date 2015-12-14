using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Projectile.Color color;
    public float forceFactor;
    public float initialForceFactor;
    public float angularSpeed;
    public float cooldownDuration;
    public float chaseRange;
    [HideInInspector]
    public bool isDead { get; private set; }
    [HideInInspector]
    public bool isCaptured { get; set; }

    GameObject player;
    Rigidbody2D rigid;
    float cooldown;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f)).normalized * initialForceFactor);
        cooldown = 0f;
        isDead = false;
        isCaptured = false;
    }

    void FixedUpdate()
    {
        if (!isCaptured) {
            Vector3 target = player.transform.position;
            target.z = transform.position.z;
            Vector3 direction = target - transform.position;
            if (direction.magnitude <= chaseRange) {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
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
