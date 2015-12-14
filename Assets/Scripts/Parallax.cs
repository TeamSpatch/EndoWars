using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{
    public float effectFactor;

    Transform camera;
    Vector3 previousPosition;

    void Start()
    {
        camera = Camera.main.transform;
        previousPosition = camera.position;
    }

    void Update()
    {
        Vector3 distance = camera.position - previousPosition;
        transform.position += Vector3.Scale(distance, new Vector3(effectFactor, effectFactor)) * -1;
        previousPosition = camera.position;
    }
}
