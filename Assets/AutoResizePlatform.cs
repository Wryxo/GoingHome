using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class AutoResizePlatform : MonoBehaviour
{
    float centerScale = 20f / 8f;
    float endSize = 6f / 20f;

    void Start()
    {
        // Remove in real game
        Destroy(this);
    }

    // Update is called whenever something in the scene changes (Edit mode only!)
    void Update()
    {
        //#if (UNITY_EDITOR)
        //Debug.Log("Update!");
        Transform left = transform.Find("Left");
        Transform right = transform.Find("Right");
        Vector3 position = (left.localPosition + right.localPosition) / 2f;
        float scale = right.position.x - left.position.x;

        //transform.position = position;

        Transform center = transform.Find("Center");
        center.localPosition = position;
        //center.localPosition = Vector3.zero;
        center.localScale = new Vector3(scale * centerScale, center.localScale.y, center.localScale.z);

        Transform collider = transform.Find("Collider");
        collider.localPosition = position;
        //collider.localPosition = Vector3.zero;
        BoxCollider2D col = collider.GetComponent<BoxCollider2D>();
        col.size = new Vector2(scale + 2f * endSize, col.size.y);


        //#endif
    }
}
