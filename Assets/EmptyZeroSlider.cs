using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class EmptyZeroSlider : MonoBehaviour
{
    Slider slider;
    GameObject fillArea;

    // Use this for initialization
    void Start()
    {
        slider = GetComponent<Slider>();
        fillArea = transform.Find("Fill Area").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Value: " + slider.normalizedValue);
        if (slider.value == 0.0f)
            fillArea.SetActive(false);
        else
        {
            fillArea.SetActive(true);
            if (slider.value < 0.05f)
                slider.value = 0.05f;
        }
    }
}
