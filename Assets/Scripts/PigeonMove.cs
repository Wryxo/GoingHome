using UnityEngine;
using System.Collections;

public class PigeonMove : MonoBehaviour
{

    public GameObject pigeon;
    //public int MaxNumberOfShits;

    float flightDuration = 2.0f;

    Transform start;
    Transform end;

    bool toTheRight = true;
    float startTime = 0;

    // Use this for initialization
    void Start()
    {
        start = transform.Find("Start");
        end = transform.Find("End");
        startTime = Time.time;
        //pigeon.GetComponent<Pigeon>().MaxNumberOfShits = MaxNumberOfShits;
    }

    // Update is called once per frame
    void Update()
    {
        float param = (Time.time - startTime) / flightDuration;
        if (toTheRight)
            pigeon.transform.position = Vector3.Lerp(start.position, end.position, param);
        else
            pigeon.transform.position = Vector3.Lerp(end.position, start.position, param);
        if (param >= 1.0)
        {
            toTheRight = !toTheRight;
			Vector3 theScale = pigeon.transform.Find("Pigeon").transform.localScale;
			theScale.x *= -1;
			pigeon.transform.Find("Pigeon").transform.localScale = theScale;
            startTime = Time.time;
        }
    }
}
