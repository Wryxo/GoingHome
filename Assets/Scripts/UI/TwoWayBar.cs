using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TwoWayBar : MonoBehaviour
{

    PlayerStats stats;
    Slider positiveSlider;
    Slider negativeSlider;

    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
        positiveSlider = transform.Find("PositiveBar").GetComponent<Slider>();
        negativeSlider = transform.Find("NegativeBar").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.Health > 0)
        {
            float percent = stats.Health / stats.MaxHealth;
            positiveSlider.normalizedValue = 0;
            negativeSlider.normalizedValue = percent;
        }
        else
        {
            float percent = -stats.Health / stats.MaxHealth;
            positiveSlider.normalizedValue = percent;
            negativeSlider.normalizedValue = 0;
        }

    }
}
