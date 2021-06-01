using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgraderManager : MonoBehaviour
{
    public static UpgraderManager instance;
    public ButtonUpgrade[] upgradesButtons;
    public int totalPoint = 0;
    [SerializeField] private Text _totalPointsText;

    private void Awake()
    {
        instance = this;
    }
    private void OnDestroy()
    {
        instance = null;
    } 

    private void Start()
    {
        UpdateTotalPoint();
        CheckPoints();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            totalPoint += 250;
            UpdateTotalPoint();
            CheckPoints();
        }
    }

    public void CheckPoints()
    {
        foreach (ButtonUpgrade button in upgradesButtons)
        {
            if (button.priseToBuy > totalPoint)
            {
                button.thisButton.interactable = false;
            }
            else
            {
                button.thisButton.interactable = true;
            }
        }
    }

    public void UpdateTotalPoint()
    {
        _totalPointsText.text = "Total Points: " + totalPoint.ToString();
    }
}
