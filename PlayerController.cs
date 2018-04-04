using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public int length;

    private Vector3 movement;
    public Vector3 lastMovement;

    public Text countText;
    public Text winText;

    public float speed;
    private int count;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";

        length = 1;
    }


    //called before physics calculations
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        lastMovement = movement;

        movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count+= 1;
            SetCountText();
            length+= 1;
        }

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 6)
        {
            winText.text = "You Win!!";
        }
    }
}
