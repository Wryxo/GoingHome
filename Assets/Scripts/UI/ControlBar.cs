using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlBar : MonoBehaviour
{

    PlayerStats stats;
    Slider slider;

    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        float percent = stats.SelfControl / 100.0f;
        slider.normalizedValue = percent;
    }
}
