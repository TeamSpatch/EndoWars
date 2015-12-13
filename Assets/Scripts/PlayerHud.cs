using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHud : MonoBehaviour
{
    PlayerStatus status;
    Text blackness;

    void Start()
    {
        status = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        blackness = transform.FindChild("Blackness").GetComponent<Text>();
    }

    void OnGUI()
    {
        blackness.text = status.blackness.ToString() + " / " + status.maxBlackness;
    }
}
