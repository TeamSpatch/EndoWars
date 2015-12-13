﻿using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public float cooldownDuration;

    Vector2 min;
    Vector2 max;
    float cooldown;

    void Start()
    {
        Transform bottomLeft = transform.FindChild("AreaBottomLeft");
        min.x = bottomLeft.position.x;
        min.y = bottomLeft.position.y;
        Transform topRight = transform.FindChild("AreaTopRight");
        max.x = topRight.position.x;
        max.y = topRight.position.y;
        cooldown = 0f;
    }

    void Update()
    {
        if (cooldown > 0f) {
            cooldown -= Time.fixedDeltaTime;
        }
        if (cooldown <= 0f) {
            Vector3 pos = new Vector3(0f, 0f, transform.position.z);
            while (true) {
                pos.x = Random.Range(min.x, max.x);
                pos.y = Random.Range(min.y, max.y);
                Vector3 p = Camera.main.WorldToScreenPoint(pos);
                if ((p.x < 0 || p.x > Camera.main.pixelWidth) && (p.y < 0 || p.y > Camera.main.pixelHeight)) {
                    break;
                }
            }
            GameObject obj = GameObject.Instantiate(Resources.Load("Enemy") as GameObject);
            obj.transform.position = pos;
            Enemy enemy = obj.GetComponent<Enemy>();
            int r = Random.Range(0, 9);
            if (r == 0) {
                enemy.color = Projectile.Color.White;
            } else if (r <= 3) {
                enemy.color = Projectile.Color.Red;
            } else if (r <= 6) {
                enemy.color = Projectile.Color.Green;
            } else {
                enemy.color = Projectile.Color.Blue;
            }
            cooldown = cooldownDuration;
        }
    }
}