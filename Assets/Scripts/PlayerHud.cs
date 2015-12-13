using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHud : MonoBehaviour
{
    PlayerStatus status;
    Text antibody;
    Text blackness;

    void Start()
    {
        status = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        antibody = transform.FindChild("Antibody").GetComponent<Text>();
        blackness = transform.FindChild("Blackness").GetComponent<Text>();
    }

    void OnGUI()
    {
        antibody.text = status.antibody.ToString() + " / " + status.maxAntibody.ToString();
        blackness.text = status.blackness.ToString() + " / " + status.maxBlackness.ToString();
    }
}
