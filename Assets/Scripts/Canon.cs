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
        cooldown = 0f;
    }

    void Update()
    {
        if (cooldown > 0f) {
            cooldown -= Time.deltaTime;
        }
        if (cooldown <= 0f) {
            GameObject obj = GameObject.Instantiate(Resources.Load("Projectile") as GameObject);
            obj.transform.position = transform.position + transform.TransformDirection(spawnOffset);
            obj.transform.rotation = transform.rotation;
            Projectile projectile = obj.GetComponent<Projectile>();
            projectile.SetColor(color);
            projectile.isFriendly = isFriendly;
            projectile.move = Quaternion.Euler(0, 0, -90) * transform.InverseTransformDirection(transform.up.normalized);
            cooldown = cooldownDuration;
        }
    }
}
