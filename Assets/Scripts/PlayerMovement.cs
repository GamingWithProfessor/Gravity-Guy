using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRGBD;
    public float gravityScaleValue = 2.5f, playerspeed = 2, jumpForce;
    private bool isGround;
    int gravdir = 1;
    int coincount=0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collision.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            coincount++;
            Debug.Log("Coins collected" + coincount);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerRGBD.gravityScale = -gravityScaleValue;
            gravdir = -1;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerRGBD.gravityScale = gravityScaleValue;
            gravdir = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space)&&(isGround == true))
        {
            playerRGBD.AddForce(new Vector2(0, gravdir * jumpForce), ForceMode2D.Impulse);
            isGround = false;
        }
    }
    private void FixedUpdate()
    {
        playerRGBD.velocity = new Vector2(playerspeed, playerRGBD.velocity.y);
    }
}