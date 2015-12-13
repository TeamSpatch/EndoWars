using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour
{
    public int maxAntibody;
    public int maxBlackness;
    [HideInInspector]
    public int blackness;

    void Start()
    {
        blackness = 0;
    }
}
