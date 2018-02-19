using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class RemoveOnEnd : MonoBehaviour
{

    Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            Destroy(gameObject);
        }
    }
}
