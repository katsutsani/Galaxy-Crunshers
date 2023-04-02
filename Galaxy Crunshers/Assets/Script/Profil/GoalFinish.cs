using System;
using UnityEngine;

public class GoalFinish : MonoBehaviour
{
    [SerializeField] GameObject button;
    bool used = false;
    bool available = false;
    public static event Action<int> AddDiamond;
    public static event Action<int> AddReputation;
    public static event Action<int> AddGold;
    void Start()
    {
        OpenProfil.OnOpenProfil += VisibleButton;
    }

    private void VisibleButton(bool goal1, bool goal2, bool goal3, bool goal4, bool goal5, bool goal6, bool goal7)
    {
        //mettre les quete fini et passer a true le goal
        if (goal1 == true && button.tag == "Quest1")
        {
            button.GetComponent<SpriteRenderer>().enabled = true;
            button.GetComponent<GoalFinish>().available = true;
        }
        if (goal2 == true && button.tag == "Quest2")
        {
            button.GetComponent<SpriteRenderer>().enabled = true;
            button.GetComponent<GoalFinish>().available = true;
        }
        if (goal3 == true && button.tag == "Quest3")
        {
            button.GetComponent<SpriteRenderer>().enabled = true;
            button.GetComponent<GoalFinish>().available = true;
        }
        if (goal4 == true && button.tag == "Quest4")
        {
            button.GetComponent<SpriteRenderer>().enabled = true;
            button.GetComponent<GoalFinish>().available = true;
        }
        if (goal5 == true && button.tag == "Quest5")
        {
            button.GetComponent<SpriteRenderer>().enabled = true;
            button.GetComponent<GoalFinish>().available = true;
        }
        if (goal6 == true && button.tag == "Quest6")
        {
            button.GetComponent<SpriteRenderer>().enabled = true;
            button.GetComponent<GoalFinish>().available = true;
        }
        if (goal7 == true && button.tag == "Quest7")
        {
            button.GetComponent<SpriteRenderer>().enabled = true;
            button.GetComponent<GoalFinish>().available = true;
        }
    }

    private void OnDisable()
    {
        OpenProfil.OnOpenProfil -= VisibleButton;
    }

    private void OnMouseDown()
    {
        if (!used && available)
        {
            switch (button.tag)
            {
                case "Quest1":
                    AddDiamond?.Invoke(5);
                    break;
                case "Quest2":
                    AddDiamond?.Invoke(10);
                    break;
                case "Quest3":
                    AddReputation?.Invoke(50);
                    AddGold?.Invoke(150);
                    break;
                case "Quest4":
                    AddDiamond?.Invoke(10);
                    break;
                case "Quest5":
                    AddReputation?.Invoke(50);
                    AddGold?.Invoke(300);
                    break;
                case "Quest6":
                    AddDiamond?.Invoke(15);
                    break;
                case "Quest7":
                    AddDiamond?.Invoke(15);
                    AddReputation?.Invoke(250);
                    break;
            }
            button.GetComponent<GoalFinish>().used = true;
            button.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
