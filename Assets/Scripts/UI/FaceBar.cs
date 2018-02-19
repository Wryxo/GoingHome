using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent(typeof(UnityEngine.UI.Image))]
public class FaceBar : MonoBehaviour
{
    public List<Sprite> sprites;
    public List<float> percents;

    PlayerStats stats;
    Image image;

    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
        image = GetComponent<Image>();
    }

    void Update()
    {
        float hp = stats.Health / stats.MaxHealth;

        //Debug.Log("hp: " + hp);

        for (int i = 0; i < percents.Count; i++)
        {
            float percent = percents[i] / 100.0f;
            if (hp <= percent)
            {
                image.sprite = sprites[i];
                break;
            }
        }
    }
}
