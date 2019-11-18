using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DealUI : MonoBehaviour
{
    public Text heartsText;

    public void UpdateHeartsUI(int current)
    {

        heartsText.text = "Do You want to buy this item for " + current.ToString() + " hearts ?";

    }
}
