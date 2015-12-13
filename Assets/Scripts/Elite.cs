using UnityEngine;
using System.Collections;

public class Elite : MonoBehaviour
{
    public float engageRange;
    public float cooldownDuration;
    public Vector3 spawnOffset;
    public bool isDead { get; private set; }

    Transform player;
    float cooldown;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (cooldown > 0f) {
            cooldown -= Time.deltaTime;
        }
        Vector3 direction = (player.position - transform.position);
        if (direction.magnitude <= engageRange) {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            if (cooldown <= 0f) {
                GameObject obj = GameObject.Instantiate(Resources.Load("WhiteProjectile") as GameObject);
                obj.transform.position = transform.position + transform.TransformDirection(spawnOffset);
                obj.transform.rotation = transform.rotation;
                Projectile projectile = obj.transform.FindChild("Projectile").GetComponent<Projectile>();
                projectile.isFriendly = false;
                projectile.move = (Quaternion.Euler(0, 0, -90) * transform.InverseTransformDirection(transform.up.normalized)).normalized;
                cooldown = cooldownDuration;
            }
        }
    }

    public void Die()
    {
        if (!isDead) {
            isDead = true;
            GameObject obj = GameObject.Instantiate(Resources.Load("Antibody") as GameObject);
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            Destroy(gameObject);
        }
    }
}
