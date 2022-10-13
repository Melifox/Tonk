/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speler : MonoBehaviour
{
    public int spelerNummer;
    [SerializeField]
    Material actiefMat;
    [SerializeField]
    Material inactiefMat;
    bool isAanDeBeurt = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().material = inactiefMat;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAanDeBeurt == true)
        {
            Invoke("WisselBeurt", 0.1f);
        }
    }

    void WisselBeurt()
    {
        GameObject.Find("GameManager").GetComponent<TurnManager>().WisselBeurt();
    }

    public void ZetActief(bool b)
    {
        if (b ==true)
        {
            isAanDeBeurt = true;
            GetComponent<SpriteRenderer>().material = actiefMat;
        }
        else
        {
            isAanDeBeurt = false;
            GetComponent<SpriteRenderer>().material = inactiefMat;
        }
    }
}
*/
