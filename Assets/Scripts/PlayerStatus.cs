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
    SpriteRenderer level1;
    SpriteRenderer level2;
    SpriteRenderer level3;
    SpriteRenderer level4;

    void Start()
    {
        antibody = 0;
        blackness = 0;
        level = 1;
        isDead = false;
        deadTimer = 5f;
        level1 = transform.FindChild("Level1").GetComponent<SpriteRenderer>();
        level2 = transform.FindChild("Level2").GetComponent<SpriteRenderer>();
        level3 = transform.FindChild("Level3").GetComponent<SpriteRenderer>();
        level4 = transform.FindChild("Level4").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isDead) {
            level1.color = Color.Lerp(level1.color, Color.black, 0.5f * Time.deltaTime);
            level2.color = Color.Lerp(level2.color, Color.black, 0.5f * Time.deltaTime);
            level3.color = Color.Lerp(level3.color, Color.black, 0.5f * Time.deltaTime);
            level4.color = Color.Lerp(level4.color, Color.black, 0.5f * Time.deltaTime);
            deadTimer -= Time.deltaTime;
            if (deadTimer <= 0f) {
                SceneManager.LoadScene("lose");
            }
        } else {
            if (level == 2) {
                {
                    Color color = level1.color;
                    color.a = (color.a <= 0.1f ? 0f : Mathf.Lerp(color.a, 0f, 0.5f * Time.deltaTime));
                    level1.color = color;
                }
                {
                    Color color = level2.color;
                    color.a = (color.a >= 0.9f ? 1f : Mathf.Lerp(color.a, 1f, 0.5f * Time.deltaTime));
                    level2.color = color;
                }
                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1.3f, 1.3f, 1f), 0.5f * Time.deltaTime);
            } else if (level == 3) {
                {
                    Color color = level2.color;
                    color.a = (color.a <= 0.1f ? 0f : Mathf.Lerp(color.a, 0f, 0.5f * Time.deltaTime));
                    level2.color = color;
                }
                {
                    Color color = level3.color;
                    color.a = (color.a >= 0.9f ? 1f : Mathf.Lerp(color.a, 1f, 0.5f * Time.deltaTime));
                    level3.color = color;
                }
                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1.6f, 1.6f, 1f), 0.5f * Time.deltaTime);
            } else if (level == 4) {
                {
                    Color color = level3.color;
                    color.a = (color.a <= 0.1f ? 0f : Mathf.Lerp(color.a, 0f, 0.5f * Time.deltaTime));
                    level3.color = color;
                }
                {
                    Color color = level4.color;
                    color.a = (color.a >= 0.9f ? 1f : Mathf.Lerp(color.a, 1f, 0.5f * Time.deltaTime));
                    level4.color = color;
                }
                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(2f, 2f, 1f), 0.5f * Time.deltaTime);
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
                if (level == 3) {
                    level1.transform.FindChild("Glow").gameObject.SetActive(false);
                    level3.transform.FindChild("Glow").gameObject.SetActive(true);
                } else if (level == 4) {
                    level3.transform.FindChild("Glow").gameObject.SetActive(false);
                    level4.transform.FindChild("Glow").gameObject.SetActive(true);
                }
            }
        }
    }
}
