using UnityEngine;
using System.Collections;

public class Elite : MonoBehaviour
{
    public float engageRange;
    public float cooldownDuration;
    public Vector3 spawnOffset;
    public bool isDead { get; private set; }

    Transform player;
    Animator animator;
    float cooldown;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Elite", true);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isDead) {
            if (cooldown > 0f) {
                cooldown -= Time.deltaTime;
            }
            Vector3 direction = (player.position - transform.position);
            if (direction.magnitude <= engageRange) {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                if (cooldown <= 0f) {
                    GameObject obj = GameObject.Instantiate(Resources.Load("WhiteProjectile") as GameObject);
                    obj.transform.position = transform.position + transform.TransformDirection(spawnOffset);
                    obj.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, Vector3.forward);
                    Projectile projectile = obj.transform.FindChild("Projectile").GetComponent<Projectile>();
                    projectile.isFriendly = false;
                    projectile.move = (Quaternion.Euler(0, 0, -90f) * transform.InverseTransformDirection(transform.up.normalized)).normalized;
                    cooldown = cooldownDuration;
                }
            }
        }
    }

    public void Die()
    {
        if (!isDead) {
            isDead = true;
            StartCoroutine(DieReal());
        }
    }

    IEnumerator DieReal()
    {
        animator.SetBool("Dead", true);
        GameObject obj = GameObject.Instantiate(Resources.Load("Antibody") as GameObject);
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
