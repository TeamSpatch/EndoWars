using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EliteSpawn : MonoBehaviour
{
    public float cooldownDuration;
    
    List<Vector3> spawns;

    void Start()
    {
        spawns = new List<Vector3>();
        for (int i = 0; i < transform.childCount; i++) {
            Transform child = transform.GetChild(i);
            if (child.name.StartsWith("EliteSpawn")) {
                spawns.Add(new Vector3(child.position.x, child.position.y, transform.position.z));
                Spawn(spawns.Count - 1);
            }
        }
    }

    void Spawn(int i)
    {
        GameObject child = GameObject.Instantiate(Resources.Load("Elite") as GameObject);
        child.transform.position = spawns[i];
    }
}