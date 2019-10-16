using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPanel : MonoBehaviour

{


    //-------------------------
    public bool canbuy;
    //-------------------------

    private DeathObject price;



    // Start is called before the first frame update
    void Start()
    {
        canbuy = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hide()
    {
        gameObject.SetActive(false);

        canbuy = false;



    }

    public void Show()
    {
        gameObject.SetActive(true);

        canbuy = true;




    }

}
