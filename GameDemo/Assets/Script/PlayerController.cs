using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playRigidbody;
    private float speed = 1.5f;
    private Vector3 movement;
    private Animator animator;

    private void Awake()
    {
        animator =GetComponent<Animator>();
        playRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Move(h, v);
        TurnBody();
        walk(h, v);
    }

    private void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playRigidbody.MovePosition(transform.position + movement);
    }

    private void walk(float h, float v)
    {
        bool isWalk = h != 0 || v != 0;
        animator.SetBool("IsWalk", isWalk);
    }

    private void TurnBody()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, 100f))
        {
            Vector3 playerToMouse = raycastHit.point - transform.position;
            playerToMouse.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(playerToMouse);
            playRigidbody.MoveRotation(targetRotation);
        }
    }

}
