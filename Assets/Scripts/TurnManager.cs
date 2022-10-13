using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private int playerTurn = 1;
    public GameObject player1;
    public GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
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
        Invoke("DisableTurn", 0.1f);
        Invoke("EnableTurn", 4f);
    }
    public void DisableTurn()
    {
        if (playerTurn == 1)
        {
            //maak speler 1 inactief
            Debug.Log("Speler1 inactive");
            player1.GetComponent<TankManager>().SetActive(false);
            
        }
        else if (playerTurn == 2)
        {
            //maak speler 2 inactief
            Debug.Log("Speler2 inactive");
            player2.GetComponent<TankManager>().SetActive(false);
            
        }
    }

    public void EnableTurn()
    {
        if (playerTurn == 1)
        {
            Debug.Log("Speler1 actief");
            player2.GetComponent<TankManager>().SetActive(true);
            playerTurn = 2;
        }
        else if (playerTurn == 2)
        {
            Debug.Log("Speler2 actief");
            player1.GetComponent<TankManager>().SetActive(true);
            playerTurn = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
