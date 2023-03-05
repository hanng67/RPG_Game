using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D theRB;
    [SerializeField] private Animator myAnim;
    [SerializeField] private float moveSpeed;

    public bool CanMove = true;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (CanMove)
        {
            theRB.velocity = new Vector2(horizontal, vertical) * moveSpeed;
        }
        else
        {
            theRB.velocity = Vector2.zero;
        }

        myAnim.SetFloat("moveX", theRB.velocity.x);
        myAnim.SetFloat("moveY", theRB.velocity.y);

        if ((horizontal == 1) || (horizontal == -1) || (vertical == 1) || (vertical == -1))
        {
            if (CanMove)
            {
                myAnim.SetFloat("lastMoveX", horizontal);
                myAnim.SetFloat("lastMoveY", vertical);
            }
        }

        float boundX = Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x);
        float boundY = Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y);
        transform.position = new Vector3(boundX, boundY, transform.position.z);
    }

    public void SetBound(Vector3 bottomLeft, Vector3 topRight)
    {
        bottomLeftLimit = bottomLeft + new Vector3(0.5f, 1f, 0f);
        topRightLimit = topRight + new Vector3(-0.5f, -1f, 0f);
    }
}
