using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class RunTheFuckAway : MonoBehaviour
{
    public float speed = 10f;

    Animator animator;

    float direction = 1f;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.CrossFade("Run", 0.2f);
        animator.SetBool("Ground", true);
        animator.SetFloat("Speed", 1f);        
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x + speed * direction * Time.deltaTime, transform.position.y, transform.position.z);
    }

    public void SetDirection(float direction)
    {
        this.direction = Mathf.Sign(direction);
    }
}
