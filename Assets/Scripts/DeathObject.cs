using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObject : MonoBehaviour
{
    public int heart = 0;
    private DealUI ui;


    // Start is called before the first frame update
    void Start()
    {

        ui = GameObject.FindGameObjectWithTag("DealPanel").GetComponent<DealUI>();
        ui.UpdateHeartsUI(heart);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
