using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoJump : MonoBehaviour
{
    PlayerController player;
    public string impactTag = "Player";

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == impactTag)
        {
            player.nojump = true;
            Destroy(gameObject);
        }

    }

}
