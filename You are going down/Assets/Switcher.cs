using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{

    private float initRotationX;
    private float step;
    public bool canTurn;
    private bool isBallHere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canTurn)
            Turn();
    }

    public void Turn()
    {
        if (transform.localEulerAngles.x * 2f >= 180 - Mathf.Epsilon)
        {
            canTurn = false;
            transform.rotation = Quaternion.identity;
            return;
        }
        step =  200 * Time.deltaTime;
        transform.Rotate(Vector3.right, step);
        print("turn");

    }

    public void SetIsBallHere(bool isBallHere)
    {
        this.isBallHere = isBallHere;
    }
    public bool GetIsBallHere()
    {
        return isBallHere;
    }

    private void OnMouseDown()
    {
        canTurn = true;

    }

}