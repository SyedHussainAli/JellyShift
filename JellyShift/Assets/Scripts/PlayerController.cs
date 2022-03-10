using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 tempScale;
    private int move = 5;
    private Rigidbody playerRB;
    AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRB = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {


        PlayerShape();
        PlayerMovement();

    }

    private void PlayerMovement()
    {
        //  transform.Translate(Vector3.forward * Time.deltaTime * move);
        playerRB.AddForce(Vector3.forward * Time.deltaTime * move, ForceMode.Impulse);
    }

    private void PlayerShape()
    {
        if (Input.GetKey(KeyCode.UpArrow) && transform.localScale.y <= 3)
        {
            tempScale = transform.localScale;
            tempScale.y += 0.1f;
            tempScale.x -= 0.1f;
            transform.localScale = tempScale;
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.localScale.x <= 3)
        {
            tempScale = transform.localScale;
            tempScale.y -= 0.1f;
            tempScale.x += 0.1f;
            transform.localScale = tempScale;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerRB.AddForce(Vector3.back * Time.deltaTime * 100, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Win"))
        {
            playerRB.isKinematic = true;
            transform.localScale = new Vector3(2, 2, 2);
            transform.position = new Vector3(0, 1.6f, 433);
            Debug.Log("Yow Win");

        }
        if (other.CompareTag("audioPlay"))
        {
            Debug.Log("TriggerWorking");
            playerAudio.Play();
        }
    }
}
