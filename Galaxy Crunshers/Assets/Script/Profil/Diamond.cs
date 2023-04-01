using UnityEngine;
using UnityEngine.UI;

public class Diamond : MonoBehaviour
{
    public Text diamond_num;

    int diamond = 999999999;

    private void Update()
    {
        diamond_num.text = diamond.ToString();
    }
}