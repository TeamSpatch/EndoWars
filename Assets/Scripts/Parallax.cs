using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{
    public float effectFactor;

    Transform reference;
    Vector3 previousPosition;

    void Start()
    {
        reference = Camera.main.transform;
        previousPosition = reference.position;
    }

    void Update()
    {
        Vector3 distance = reference.position - previousPosition;
        transform.position += Vector3.Scale(distance, new Vector3(effectFactor, effectFactor)) * -1;
        previousPosition = reference.position;
    }
}
