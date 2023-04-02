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
        Building.DimondPrice += Building_DimondPrice;
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