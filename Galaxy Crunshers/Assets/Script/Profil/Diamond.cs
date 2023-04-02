using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Diamond : MonoBehaviour
{
    public Text diamond_num;

    int diamond = 999999999;
    int price = 0;

    private void Start()
    {
        GoalFinish.AddDiamond += addDiamond;
        Building.DimondPrice += Building_DimondPrice;
    }

    private void addDiamond(int quantity)
    {
        diamond += quantity;
    }

    private void Building_DimondPrice(int buy)
    {
        price = buy;
        diamond -= price;
    }

    private void OnDisable()
    {
        Building.DimondPrice -= Building_DimondPrice;
    }

    private void Update()
    {
        diamond_num.text = diamond.ToString();
    }
}