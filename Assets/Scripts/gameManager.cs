using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static TMP_Text yukseklik;
    private GameObject player;
    float playerPosY;
    int ilkYukseklik;
    int metre = 0;
    int currentScene;
    void Start()
    {
        yukseklik = GameObject.Find("Yükseklik").GetComponent<TMP_Text>();
        player = GameObject.FindWithTag("Player");
        ilkYukseklik = (int)player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosY = (int)player.transform.position.y - ilkYukseklik;
        playerPosY = (int)playerPosY / 2;
        if (playerPosY > metre)
        {
            metre = (int)playerPosY;
            yukseklik.text = playerPosY.ToString() + "m";
        }
        
        
    }

    public void TekrarBasla()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
