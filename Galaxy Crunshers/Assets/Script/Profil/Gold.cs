using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public Text gold_num;
    int gold;
    private int price;

    private void Awake()
    {
        gold = 50000;
    }

    private void Start()
    {
        AddCharacter.OnCharacterAdded += AddCharacter_OnCharacterAdded;
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
