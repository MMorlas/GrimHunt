using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        OpenPause(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPause(bool open)
    {
        pausePanel.SetActive(open);
    }
}
