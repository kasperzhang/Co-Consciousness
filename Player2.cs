using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GravityStatus
{
    Normal,
    Reverse
}

public class Player2 : Player
{
    public float jumpSpeed = 5f;
    public int jumpAmount = 0;

    private GroundCheck _groundCheck;

    private GravityStatus _gravityStatus;

    protected override void OnInit()
    {
        _groundCheck = transform.Find("Ground").GetComponent<GroundCheck>();

        _gravityStatus = GravityStatus.Normal;
    }

    protected override void OnMove()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            IsMoving = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            IsMoving = true;
        }

        if (Input.GetKeyUp(KeyCode.W) && jumpAmount < Constants.PlayerJumpAmount)
        {
            Rigidbody2D.velocity = Vector2.zero;
            switch (_gravityStatus)
            {
                case GravityStatus.Reverse:
                    Rigidbody2D.AddForce(new Vector2(0, -jumpSpeed));
                    break;
                default:
                    Rigidbody2D.AddForce(new Vector2(0, jumpSpeed));
                    break;
            }

            jumpAmount += 1;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            IsMoving = false;
        }
    }

    protected override void OnUpdate()
    {
        ReverseGravity();
    }

    private void ReverseGravity()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            switch (_gravityStatus)
            {
                case GravityStatus.Normal:
                    _gravityStatus = GravityStatus.Reverse;
                    break;
                case GravityStatus.Reverse:
                    _gravityStatus = GravityStatus.Normal;
                    break;
            }
            
            Rigidbody2D.gravityScale = -Rigidbody2D.gravityScale;

            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        }
    }
}