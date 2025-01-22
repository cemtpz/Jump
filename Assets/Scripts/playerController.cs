using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class playerController : MonoBehaviour
{
    bool onFloor;

    [SerializeField] float jumpForce;
    [SerializeField] float screenLimit;
    float worldPosX;
    public float jumpTime;
    float timeRemaining;
    public int speed;

    private Rigidbody2D rb;
    public GameObject kaybetme;
    private Animator playerAnimator;

    Vector3 screenPosition;
    Vector3 worldPosition;
    Vector3 touchPosition;

    public TMP_Text score;
    void Start()
    {
        timeRemaining = jumpTime;
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerAnimator.SetBool("isJump", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        
        if (collision.gameObject.tag == "Floor")
        {
            onFloor = true;
            playerAnimator.SetBool("onFloor", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lose Zone"))
        {
            score.text = "Score: " + gameManager.yukseklik.text;
            kaybetme.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        }

        

        if (playerAnimator.GetBool("isJump"))
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                playerAnimator.SetBool("isJump", false);
                timeRemaining = jumpTime;
            }
        }

        if (Input.touchCount > 0)
        {
            if (touchPosition.x <= -0.5)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                playerAnimator.SetBool("isRun", true);
            }
            else if (touchPosition.x >= 0.5)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                playerAnimator.SetBool("isRun", true);
            }
            
        }
        else if (Input.touchCount == 0)
        {
            playerAnimator.SetBool("isRun", false);
        }



    }

    void FixedUpdate()
    {
        if (onFloor)
        {
            if (Input.touchCount > 0)
            {
                if (touchPosition.x > -0.5 && touchPosition.x < 0.5)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    onFloor = false;
                    playerAnimator.SetBool("onFloor", false);
                    playerAnimator.SetBool("isJump", true);
                }
            }

            // Space tuþuna basarak karakteri zýplatma:

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                onFloor = false;
                playerAnimator.SetBool("onFloor", false);
                playerAnimator.SetBool("isJump", true);
            }
        }
        // Karakteri "A" ve "D" tuþlarýna göre hareket ettirme:
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, 0f);


        if (Input.touchCount > 0)
        {
            if (touchPosition.x <= -0.5)
            {
                rb.velocity = new Vector3(-1 * speed, rb.velocity.y, 0f);
            }
            else if (touchPosition.x >= 0.5)
            {
                rb.velocity = new Vector3(1 * speed, rb.velocity.y, 0f);
            }
        }
        

        /* Karakteri mouse pozisyonuna göre hareket ettirme:
         
        screenPosition = Input.mousePosition;
        
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        worldPosX = Mathf.Clamp(worldPosition.x, -screenLimit, screenLimit);

        transform.position = new Vector3(worldPosX, transform.position.y, transform.position.z);
        */
    }
}
