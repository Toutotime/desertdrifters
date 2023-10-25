using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerJump : MonoBehaviour

{
    public bool touchingGround = true;
    public bool checkForGroundTouch = true;
    public float jumpForce = 100000f;
    private IEnumerator jumpCooldown()
    {
        checkForGroundTouch = false;
        yield return new WaitForSeconds(0.03f);
            checkForGroundTouch = true;
    }
    private void groundChecker()
    {
        RaycastHit hit;
            bool rayHitGround = 
                 Physics.Raycast(transform.position,transform.TransformDirection(Vector3.down), out hit);
                 if (checkForGroundTouch && rayHitGround)    
        {
                if (hit.distance < .020F)
            {
                    touchingGround = true;
                    Debug.Log("distance: " + hit.distance);
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && touchingGround)
        { 
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * jumpForce);
             touchingGround = false;
             StartCoroutine(jumpCooldown());

        }
        groundChecker();
    }
}
