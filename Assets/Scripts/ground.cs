using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    private GameObject player;
    float randomPosX;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (transform.position.y >= player.transform.position.y)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lose Zone"))
        {
            randomPosX = Random.Range(-2f, 2f);
            transform.position = new Vector3(randomPosX, transform.position.y + 3.32f * 4, transform.position.z);
        }
    }
}
