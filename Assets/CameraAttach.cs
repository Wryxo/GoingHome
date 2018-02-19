using UnityEngine;
using System.Collections;

public class CameraAttach : MonoBehaviour
{
    Transform camera;

    // Use this for initialization
    void Start()
    {
        camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(camera.position.x, camera.position.y, transform.position.z);
        transform.position = pos;
    }
}
