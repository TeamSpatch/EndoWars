using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHud : MonoBehaviour
{
    PlayerStatus status;
    Text level;
    Text antibody;
    Text blackness;

    void Start()
    {
        status = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        level = transform.FindChild("Level").GetComponent<Text>();
        antibody = transform.FindChild("Antibody").GetComponent<Text>();
        blackness = transform.FindChild("Blackness").GetComponent<Text>();
    }

    void OnGUI()
    {
        level.text = status.level.ToString();
        antibody.text = status.antibody.ToString() + " / " + PlayerStatus.maxAntibody.ToString();
        blackness.text = status.blackness.ToString() + " / " + status.maxBlackness.ToString();
    }
}
