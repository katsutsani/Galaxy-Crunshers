using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowShop : MonoBehaviour
{
    [SerializeField] GameObject OpenButton;
    [SerializeField] GameObject CloseButton;
    [SerializeField] GameObject Map;
    [SerializeField] TextMeshProUGUI ShopTitle;
    [SerializeField] GameObject ShopBackground;
    public static event Action reload;
    public static event Action removeName;
    public void OpenMenu()
    {
        OpenButton.SetActive(false);
        CloseButton.SetActive(true);
        Map.SetActive(false);
        ShopTitle.enabled = true;
        ShopBackground.SetActive(true);
    }

    public void CloseShop()
    {
        OpenButton.SetActive(true);
        CloseButton.SetActive(false);
        Map.SetActive(true);
        ShopTitle.enabled = false;
        ShopBackground.SetActive(false);
        reload?.Invoke();
        removeName?.Invoke();
    }
}
