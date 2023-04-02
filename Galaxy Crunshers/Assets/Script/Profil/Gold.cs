using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public Text gold_num;
    public int gold;
    private int price;


    private void Start()
    {
        AddCharacter.OnCharacterAdded += AddCharacter_OnCharacterAdded;
        Building.UpgradeGold += Building_UpgradeGold;
        gold = 500000;
    }

    private void Building_UpgradeGold(int obj)
    {
        price = obj;
        gold += price;
    }

    private void AddCharacter_OnCharacterAdded(int buy)
    {
        price = buy;
        gold -= price;
    }

    private void OnDisable()
    {
        AddCharacter.OnCharacterAdded -= AddCharacter_OnCharacterAdded;
    }

    private void Update()
    {
        gold_num.text = gold.ToString();
    }
}
