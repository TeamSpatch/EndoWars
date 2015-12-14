using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EliteSpawn : MonoBehaviour
{
    public float cooldownDuration;

    int count;
    int max;
    List<Vector3> spawns;
    float cooldown;

    void Start()
    {
        count = 0;
        max = 0;
        spawns = new List<Vector3>();
        for (int i = 0; i < transform.childCount; i++) {
            Transform child = transform.GetChild(i);
            if (child.name.StartsWith("EliteSpawn")) {
                spawns.Add(new Vector3(child.position.x, child.position.y, transform.position.z));
                Spawn(spawns.Count - 1);
                ++max;
            }
        }
    }

    void Update()
    {
        if (count < max) {
            if (cooldown >= 0f) {
                cooldown -= Time.deltaTime;
            }
            if (cooldown <= 0f) {
                Spawn(Random.Range(0, spawns.Count - 1));
                cooldown = cooldownDuration;
            }
        }
    }

    void Spawn(int i)
    {
        GameObject child = GameObject.Instantiate(Resources.Load("Elite") as GameObject);
        child.transform.position = spawns[i] + new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0f);
        ++count;
    }

    public void Died()
    {
        --count;
    }
}