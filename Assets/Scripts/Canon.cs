using UnityEngine;
using System.Collections;

public class Canon : MonoBehaviour
{
    public Projectile.Color color;
    public float cooldownDuration;
    public Vector3 spawnOffset;
    public bool isFriendly;

    float cooldown;

    void Start()
    {
        cooldown = cooldownDuration;
    }

    void Update()
    {
        if (cooldown > 0f) {
            cooldown -= Time.deltaTime;
        }
        if (cooldown <= 0f) {
            GameObject obj;
            if (color == Projectile.Color.Red) {
                obj = GameObject.Instantiate(Resources.Load("RedProjectile") as GameObject);
            } else if (color == Projectile.Color.Green) {
                obj = GameObject.Instantiate(Resources.Load("GreenProjectile") as GameObject);
            } else {
                obj = GameObject.Instantiate(Resources.Load("WhiteProjectile") as GameObject);
            }
            obj.transform.position = transform.position + transform.TransformDirection(spawnOffset);
            obj.transform.rotation = transform.rotation;
            Projectile projectile = obj.transform.FindChild("Projectile").GetComponent<Projectile>();
            projectile.isFriendly = isFriendly;
            projectile.move = (Quaternion.Euler(0, 0, -90) * transform.InverseTransformDirection(transform.up.normalized)).normalized;
            cooldown = cooldownDuration;
        }
    }
}
