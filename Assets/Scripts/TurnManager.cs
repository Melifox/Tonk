using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour
{
    private int playerTurn = 1;
    public GameObject player1;
    public GameObject player2;
    public bool bothPlayersAlive = true;
    GameObject restartMenu;

    // Start is called before the first frame update
    void Start()
    {
        restartMenu = GameObject.FindGameObjectWithTag("RestartMenu");
        restartMenu.SetActive(false);
        GameObject.Find("Turnindicator1").GetComponent<SpriteRenderer>().color = Color.green;
        GameObject.Find("Turnindicator2").GetComponent<SpriteRenderer>().color = Color.red;
        GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
        foreach (GameObject g in players)
        {
            if (g.GetComponent<TankManager>().playerNumber == 1)
            {
                player1 = g;
            }
            else if (g.GetComponent<TankManager>().playerNumber == 2)
            {
                player2 = g;
            }
        }
        Invoke("Init", 0.1f);
    }
    void Init()
    {    
        //de speler die aan de beurt is actief maken
        if (playerTurn == 1)
        {
            //maak speler 1 actief
            player1.GetComponent<TankManager>().SetActive(true);
            player2.GetComponent<TankManager>().SetActive(false);
        }
    } 

    public void ChangeTurn()
    {
        Invoke("DisableTurn", 0.001f);
        Invoke("EnableTurn", 4f);
    }
    public void DisableTurn()
    {
        if (playerTurn == 1)    
        {
            
            //maak speler 1 inactief
            Debug.Log("Speler1 inactive");
            player1.GetComponent<TankManager>().SetActive(false);
            GameObject.Find("Turnindicator1").GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (playerTurn == 2)
        {
            //maak speler 2 inactief
            Debug.Log("Speler2 inactive");
            player2.GetComponent<TankManager>().SetActive(false);
            GameObject.Find("Turnindicator2").GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    public void EnableTurn()
    {
        if (playerTurn == 1)
        {
            Debug.Log("Speler1 actief");
            player2.GetComponent<TankManager>().SetActive(true);
            playerTurn = 2;
            GameObject.Find("Turnindicator2").GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (playerTurn == 2)
        {
            Debug.Log("Speler2 actief");
            player1.GetComponent<TankManager>().SetActive(true);
            playerTurn = 1;
            GameObject.Find("Turnindicator1").GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("URP2DSceneTemplate");
    }

    // Update is called once per frame
    void Update()
    {
        if (bothPlayersAlive == false)
        {
            restartMenu.SetActive(true);
        }
    }
}