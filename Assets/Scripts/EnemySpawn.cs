using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public float cooldownDuration;
    public Rect area;

    float cooldown;

    void Start()
    {
        cooldown = 0f;
    }

    void Update()
    {
        if (cooldown > 0f) {
            cooldown -= Time.fixedDeltaTime;
        }
        if (cooldown <= 0f) {
            cooldown = cooldownDuration;
        }
    }
}
