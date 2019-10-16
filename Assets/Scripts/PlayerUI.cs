using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text ammoText;
    public Image barLife;

    public void UpdateLifeUI(float newLife, float maxLife)
    {
        barLife.fillAmount = newLife / maxLife;
    }


}
