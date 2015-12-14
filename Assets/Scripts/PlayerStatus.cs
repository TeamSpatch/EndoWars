using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerStatus : MonoBehaviour
{
    public static int maxAntibody = 5;

    public int maxBlackness;
    public int blacknessByLevel;
    [HideInInspector]
    public int antibody { get; private set; }
    [HideInInspector]
    public int blackness { get; private set; }
    [HideInInspector]
    public int level { get; private set; }

    bool isDead;
    float deadTimer;
    SpriteRenderer sprite;

    void Start()
    {
        antibody = 0;
        blackness = 0;
        level = 1;
        isDead = false;
        deadTimer = 5f;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isDead) {
            sprite.color = Color.Lerp(sprite.color, Color.black, 0.5f * Time.deltaTime);
            deadTimer -= Time.deltaTime;
            if (deadTimer <= 0f) {
                SceneManager.LoadScene("lose");
            }
        }
    }


    public void Hook()
    {
        if (!isDead && blackness < maxBlackness) {
            ++blackness;
            if (blackness == maxBlackness) {
                isDead = true;
                GetComponent<PlayerMovement>().enabled = false;
                GetComponent<PlayerRotation>().enabled = false;
                transform.FindChild("Canon").GetComponent<Canon>().enabled = false;
            }
        }
    }

    public void Damage()
    {
        if (!isDead && antibody > 0) {
            --antibody;
        }
    }

    public void Gain()
    {
        if (!isDead && antibody < maxAntibody) {
            ++antibody;
            if ((level == 1 && antibody == 1) || (level == 2 && antibody == 3) || (level == 3 && antibody == 5)) {
                ++level;
                maxBlackness += blacknessByLevel;
            }
        }
    }
}
