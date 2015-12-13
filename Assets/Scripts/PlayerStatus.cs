using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour
{
    public int maxAntibody;
    public int maxBlackness;
    [HideInInspector]
    public int antibody
    {
        get
        {
            return _antibody;
        }
        set
        {
            if (value > 0 && value <= maxAntibody) {
                _antibody = value;
            }
        }
    }
    [HideInInspector]
    public int blackness
    {
        get
        {
            return _blackness;
        }
        set
        {
            if (value > 0 && value <= maxBlackness) {
                _blackness = value;
            }
        }
    }

    int _antibody;
    int _blackness;

    void Start()
    {
        antibody = 0;
        blackness = 0;
    }
}
