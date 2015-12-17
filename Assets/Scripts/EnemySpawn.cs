using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public float cooldownDuration;
    public int numberBySpawn;
    public bool onSite;

    Vector2 min;
    Vector2 max;
    float cooldown;

    void Start()
    {
        if (!onSite) {
            Transform bottomLeft = transform.FindChild("AreaBottomLeft");
            min.x = bottomLeft.position.x;
            min.y = bottomLeft.position.y;
            Transform topRight = transform.FindChild("AreaTopRight");
            max.x = topRight.position.x;
            max.y = topRight.position.y;
        }
        cooldown = 0f;
    }

    void Update()
    {
        if (cooldown > 0f) {
            cooldown -= Time.fixedDeltaTime;
        }
        if (cooldown <= 0f) {
            if (onSite) {
                StartCoroutine(BossAnimation());
            }
            for (int i = 0; i < numberBySpawn; i++) {
                Vector3 pos = new Vector3(0f, 0f, transform.position.z);
                if (onSite) {
                    pos.x = transform.position.x;
                    pos.y = transform.position.y;
                    StartCoroutine(SpawnAnimation(pos));
                } else {
                    while (true) {
                        pos.x = Random.Range(min.x, max.x);
                        pos.y = Random.Range(min.y, max.y);
                        Vector3 p = Camera.main.WorldToScreenPoint(pos);
                        if ((p.x < 0 || p.x > Camera.main.pixelWidth) && (p.y < 0 || p.y > Camera.main.pixelHeight)) {
                            break;
                        }
                    }
                    GameObject obj;
                    int r = Random.Range(0, 2);
                    if (r == 0) {
                        obj = GameObject.Instantiate(Resources.Load("RedEnemy") as GameObject);
                    } else {
                        obj = GameObject.Instantiate(Resources.Load("GreenEnemy") as GameObject);
                    }
                    obj.transform.position = pos;
                }
                cooldown = cooldownDuration;
            }
        }
    }

    IEnumerator BossAnimation()
    {
        Debug.Log(transform.name);
        Debug.Log(transform.parent.name);
        Debug.Log(transform.parent.parent.name);
        Animator tongue = transform.parent.parent.gameObject.GetComponent<Animator>();
        tongue.SetBool("Spawn", true);
        yield return new WaitForSeconds(0.8f);
        tongue.SetBool("Spawn", false);
    }

    IEnumerator SpawnAnimation(Vector3 pos)
    {
        yield return new WaitForSeconds(0.8f);
        GameObject obj;
        int r = Random.Range(0, 2);
        if (r == 0) {
            obj = GameObject.Instantiate(Resources.Load("RedEnemy") as GameObject);
        } else {
            obj = GameObject.Instantiate(Resources.Load("GreenEnemy") as GameObject);
        }
        obj.transform.position = pos;
    }
}
