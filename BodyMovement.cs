using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{

    public GameObject player;

    public GameObject leader;

    private Rigidbody rb;

    public int position;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - leader.transform.position;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is run every frame but after all items have been processed in Update
    void LateUpdate()
    {
        //transform.position = leader.transform.position + offset;

        player = GameObject.Find("Player");
        PlayerController p = player.GetComponent<PlayerController>();

        if (p.length >= position)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

}
