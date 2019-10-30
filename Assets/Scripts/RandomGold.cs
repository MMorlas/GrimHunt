using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGold : MonoBehaviour
{
    public string impactTag = "Player";
    public int coins;

    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        GenerateCoins();

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Seal)  CUANDO ACABE RONDA SE GENERARA LAS MONEDAS
        {
            GenerateCoins();
        }
        */
    }

    void GenerateCoins()
    {
        coins = Random.Range(15, 21);
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == impactTag)
        {
            collision.GetComponent<PlayerController>().GetCoins(coins);
            gameObject.SetActive(false);
        }

    }
}
