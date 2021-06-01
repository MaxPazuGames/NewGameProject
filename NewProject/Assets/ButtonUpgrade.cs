using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUpgrade : MonoBehaviour
{
    public enum Upgrades { upgrade1, upgrade2, upgrade3, upgrade4}
    public Upgrades upgrades;
    public int priseToBuy;
    public Text prise;
    public Button thisButton;

    private void Start()
    {
        UpdatePrise();
    }

    public void Upgrade()
    {
        if (priseToBuy <= UpgraderManager.instance.totalPoint)
        {
            UpgraderManager.instance.totalPoint -= priseToBuy;
            //switch (upgrades)
            //{
            //    case Upgrades.upgrade1:
            //        break;
            //    case Upgrades.upgrade2:
            //        break;
            //    case Upgrades.upgrade3:
            //        break;
            //    case Upgrades.upgrade4:
            //        break;
            //}
            Debug.Log(upgrades + " Updated");
            priseToBuy += 25;
            UpdatePrise();
            UpgraderManager.instance.CheckPoints();
        }
    }

    void UpdatePrise()
    {
        prise.text = "Cost: " + priseToBuy.ToString();
        UpgraderManager.instance.UpdateTotalPoint();
    }
}
