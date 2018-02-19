using UnityEngine;
using System.Collections;

public class BlackScreenMover : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z);
    }
}
