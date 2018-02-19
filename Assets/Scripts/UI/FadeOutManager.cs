using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class FadeOutManager : MonoBehaviour
{
    public float alpha = 0f;

    public float inTime = 0.3f;
    public float outTime = 1.0f;

    CanvasGroup group;
    Image image;
    float lastTime;
    bool gaining;
    bool animating;

    void Start()
    {
        gaining = true;
        animating = true;
        group = GetComponent<CanvasGroup>();
        //group.alpha = 0.5f;
        lastTime = Time.time;
        image = transform.FindChild("You Lost Control").GetComponent<Image>();
    }

    void Update()
    {
        if (animating)
        {
            if (gaining)
            {
                alpha += Time.deltaTime / inTime;
                if (Time.time - lastTime > inTime)
                {
                    gaining = false;
                    lastTime = Time.time;
                    alpha = 1f;
                }
            }
            else
            {
                alpha -= Time.deltaTime / outTime;
                if (Time.time - lastTime > outTime)
                {
                    animating = false;
                    alpha = 0f;
                }
            }
        }
        //group.alpha = alpha;
        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
        Debug.Log("Alpha: " + alpha);
    }
}
