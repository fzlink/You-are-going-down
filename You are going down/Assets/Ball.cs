using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private bool canMove = true;
    private bool canTurnSwitcher = true;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ClickCollider"))
            return;
        if (canTurnSwitcher)
        {
            canMove = false;
            canTurnSwitcher = false;
            other.gameObject.transform.parent.gameObject.SendMessage("SetIsBallHere", true);
            
            offset = transform.position - other.GetComponent<Renderer>().bounds.center;
        }
        if(other.gameObject.transform.parent.gameObject.GetComponent<Switcher>().canTurn)
            FollowSwithcer(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ClickCollider"))
            return;
        other.gameObject.transform.parent.gameObject.SendMessage("SetIsBallHere", false);
    }

    private void FollowSwithcer(Collider other)
    {
        transform.localPosition = other.GetComponent<Renderer>().bounds.center + offset;
    }
}
