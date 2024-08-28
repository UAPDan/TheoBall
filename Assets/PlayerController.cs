using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 moveDirection;
    public float speed;
    public bool isRunning;

    public Rigidbody rb;
    public float jumpForce;

    public GameObject arm;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(x, 0, z);
        transform.Translate(moveDirection * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //Using a rigidbody
            rb.velocity = new Vector3(0, jumpForce, 0);
        }


        //Running
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = !isRunning; //swaps isRunning between true and false
        }

        if (isRunning)
        {
            speed = Mathf.Lerp(5f, 10f, Time.deltaTime);
        }
        else
        {
            speed = 5;
        }
    }
}