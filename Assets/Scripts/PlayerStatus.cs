using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour
{
    public int maxAntibody;
    public int maxBlackness;
    [HideInInspector]
    public int antibody { get; private set; }
    [HideInInspector]
    public int blackness { get; private set; }

    int level;

    void Start()
    {
        antibody = 0;
        blackness = 0;
        level = 0;
    }

    public void Hook()
    {
        if (blackness < maxBlackness) {
            ++blackness;
        }
    }

    public void Damage()
    {
        if (antibody > 0) {
            --antibody;
        }
    }

    public void Gain()
    {
        if (antibody < maxAntibody) {
            ++antibody;
        }
    }
}
