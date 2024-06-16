using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI ctText;
    private int coffeeBeanCt;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private float jumpForce;
    public float speed = 0;

    private bool isGrounded;
    private float gravityModifier;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coffeeBeanCt = 0;
        jumpForce = 10f;
        gravityModifier = 2f;
        isGrounded = true;

        Physics.gravity *= gravityModifier;

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        ctText.text = "Coffee Beans: " + coffeeBeanCt.ToString();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    void OnTriggerEnter(Collider other)
    {
        string collectTag = "Collectible";

        if (other.gameObject.CompareTag(collectTag)) 
        {
            other.gameObject.SetActive(false);
            coffeeBeanCt += 1;
            SetCountText();
        }
    }

}
