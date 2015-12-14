using UnityEngine;
using System.Collections;

public class Antibody : MonoBehaviour
{
    PlayerStatus status;

    void Start()
    {
        status = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            if (status.antibody < PlayerStatus.maxAntibody) {
                status.Gain();
                Destroy(gameObject);
            }
        }
    }
}
