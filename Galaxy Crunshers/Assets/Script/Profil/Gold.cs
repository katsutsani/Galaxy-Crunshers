using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public Text gold_num;
    int gold = 10000000;
    private void Update()
    {
        gold_num.text = gold.ToString();
    }
}
