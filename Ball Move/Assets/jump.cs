using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public bool onground;
    private Rigidbody rb;
    public float jumpf;

    void Start()
    {
        onground = true;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (onground)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpb();
            }
        }
    }

    public void jumpb()
    {
        rb.velocity = new Vector3(0f, jumpf, 0f);
        onground = false;
    }

    void OnCollisionEnter(Collision Other)
    {
        if (Other.gameObject.CompareTag("Ground"))
        {
            onground = true;
        }
    }

    

}
