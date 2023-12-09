using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGround = false;
    public Player2 player;

    private void Start()
    {
        player = transform.parent.GetComponent<Player2>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("block"))
        {
            // Debug.Log($"OnTriggerEnter2D");
            
            isGround = true;
            
            player.jumpAmount = 0;

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("block"))
        {
            // Debug.Log($"OnTriggerStay2D");
            
            isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("block"))
        {
            // Debug.Log($"OnTriggerExit2D");
            
            isGround = false;
        }
    }
}
