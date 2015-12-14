using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHud : MonoBehaviour
{
    PlayerStatus status;
    List<Image> stars;
    List<Image> nails;
    Text blackness;

    void Start()
    {
        status = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        stars = new List<Image>();
        nails = new List<Image>();
        for (int i = 0; i < 5; i++) {
            stars.Add(transform.FindChild("Star" + (i + 1).ToString()).gameObject.GetComponent<Image>());
        }
        for (int i = 0; i < 3; i++) {
            nails.Add(transform.FindChild("Nail" + (i + 1).ToString()).gameObject.GetComponent<Image>());
        }
        blackness = transform.FindChild("Blackness").GetComponent<Text>();
    }

    void OnGUI()
    {
        for (int i = 0; i < 5; i++) {
            stars[i].gameObject.SetActive(i < status.antibody);
        }
        for (int i = 0; i < 3; i++) {
            nails[i].gameObject.SetActive(i + 1 < status.level);
        }
        blackness.text = status.blackness.ToString() + " / " + status.maxBlackness.ToString();
    }
}
