using UnityEngine;
using System.Collections;

public class Glow : MonoBehaviour
{
    public float minAlpha;
    public float maxAlpha;
    public float speed;

    float alpha;
    bool descending;
    SpriteRenderer sprite;

    void Start()
    {
        alpha = maxAlpha;
        descending = true;
        sprite = GetComponent<SpriteRenderer>();
        Color color = sprite.color;
        color.a = alpha;
        sprite.color = color;
    }

    void Update()
    {
        Color color = sprite.color;
        if (descending) {
            alpha -= speed * Time.deltaTime;
            color.a = alpha;
            sprite.color = color;
            if (alpha <= minAlpha) {
                descending = false;
            }
        } else {
            alpha += speed * Time.deltaTime;
            color.a = alpha;
            sprite.color = color;
            if (alpha >= maxAlpha) {
                descending = true;
            }
        }
    }
}
