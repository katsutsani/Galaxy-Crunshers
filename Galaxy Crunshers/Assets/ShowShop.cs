using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowShop : MonoBehaviour
{
    [SerializeField] GameObject OpenButton;
    [SerializeField] GameObject ShopUi;
    [SerializeField] GameObject Map;
    [SerializeField] GameObject CharacterShop;
    [SerializeField] GameObject BuildingShop;
    [SerializeField] GameObject DiamondsShop;
    [SerializeField] GameObject ChangeShop;
    [SerializeField] GameObject JustOpenedShop;
    public static event Action reload;
    public static event Action removeName;
    public void OpenMenu()
    {
        OpenButton.SetActive(false);
        ShopUi.SetActive(true);
        Map.SetActive(false);
    }

    public void CloseShop()
    {
        OpenButton.SetActive(true);
        ShopUi.SetActive(false);
        Map.SetActive(true);
        ChangeShop.SetActive(false);
        DiamondsShop.SetActive(false);
        BuildingShop.SetActive(false);
        CharacterShop.SetActive(false);
        JustOpenedShop.SetActive(true);
        reload?.Invoke();
        removeName?.Invoke();
    }

    public void ShowCharacterShop()
    {
        CharacterShop.SetActive(true);
        ChangeShop.SetActive(true);
        JustOpenedShop.SetActive(false);
        DiamondsShop.SetActive(false);
        BuildingShop.SetActive(false);
    }
    public void ShowDiamondsShop()
    {
        DiamondsShop.SetActive(true);
        ChangeShop.SetActive(true);
        JustOpenedShop.SetActive(false);
        BuildingShop.SetActive(false);
        CharacterShop.SetActive(false);
    }
    public void ShowBuildingsShop()
    {
        BuildingShop.SetActive(true);
        ChangeShop.SetActive(true);
        JustOpenedShop.SetActive(false);
        CharacterShop.SetActive(false);
        DiamondsShop.SetActive(false);
    }

    public void ShowBuildingsShopOnArea()
    {
        BuildingShop.SetActive(true);
        ChangeShop.SetActive(false);
        JustOpenedShop.SetActive(false);
        CharacterShop.SetActive(false);
        DiamondsShop.SetActive(false);
    }
}
