using UnityEngine;
using System.Collections;
using UnityEngine.UI;


[RequireComponent(typeof(UnityEngine.UI.Slider))]
public class HealthBar : MonoBehaviour
{
    PlayerStats stats;
    Slider slider;   

    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float percent = stats.Health / stats.MaxHealth;
        slider.normalizedValue = percent;
    }
}
