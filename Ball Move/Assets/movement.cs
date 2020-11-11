using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class movement : MonoBehaviour
{

    bool moveRight = false, moveLeft = false;
    [SerializeField] Rigidbody rb;
    [SerializeField] Camera c;
    GameObject touchedObject;
    RaycastHit hit;




    void Update()
    {
        //prevent Double Jump
        var Grounded = true;
        Grounded = Physics.Raycast(transform.position - Vector3.up * .2f, Vector3.down, .09f);

        //check the touched object is ball or not
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = c.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    touchedObject = hit.transform.gameObject;
                    if (touchedObject.transform.name == "Soccer Ball" && Grounded)
                    {
                        rb.velocity = new Vector3(0, 5f, 0);


                    }
                }

            }
        }

        //movement
        if (Grounded)//prevent air control
        {
            if (moveRight == true && touchedObject.transform.name != "Soccer Ball")
            {
                rb.velocity = new Vector3(Time.deltaTime * 100, 0, 0);

            }
            if (moveRight == false && moveLeft == false)
            {
                rb.velocity = new Vector3(Time.deltaTime * 00, rb.velocity.y, 0);
            }

            if (moveLeft == true && touchedObject.transform.name != "Soccer Ball")
            {

                rb.velocity = new Vector3(-Time.deltaTime * 100, 0, 0);

            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.8f, 2.8f), transform.position.y, transform.position.z);
        }

    }

    public void MoveRight()
    {
        moveRight = true;
    }

    public void notMoveRight()
    {
        moveRight = false;
    }
    public void MoveLeft()
    {
        moveLeft = true;
    }

    public void notMoveLeft()
    {
        moveLeft = false;
    }
}
