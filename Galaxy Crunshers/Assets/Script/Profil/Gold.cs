using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public Text gold_num;
    int gold = 10000000;
    private int price = 0;

    private void Start()
    {
        AddCharacter.OnCharacterAdded += AddCharacter_OnCharacterAdded;
    }

    private void AddCharacter_OnCharacterAdded(int buy)
    {
        price = buy;
        gold -= price;
    }

    private void Update()
    {
        gold_num.text = gold.ToString();
    }
}
