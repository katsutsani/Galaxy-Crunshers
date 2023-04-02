using System;
using TMPro;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class OpenProfil : MonoBehaviour
{
    [SerializeField] private bool profilOpen = false;
    [SerializeField] private bool goal1 = false;
    [SerializeField] private bool goal2 = false;
    [SerializeField] private bool goal3 = false;
    [SerializeField] private bool goal4 = false;
    [SerializeField] private bool goal5 = false;
    [SerializeField] private bool goal6 = false;
    [SerializeField] private bool goal7 = false;
    [SerializeField] GameObject scrollbar;
    private GameObject GameInfo;
    public static event Action<bool, bool, bool, bool, bool, bool, bool> OnOpenProfil;

    private void Start()
    {
        GameInfo = GameObject.FindGameObjectWithTag("GameInfo");
    }
    public void OpenProfilPlayer()
    {
        if(GameInfo.GetComponent<GameInfo>().Paysan >= 2)
        {
            goal1= true;
        }
        if (GameInfo.GetComponent<GameInfo>().Champ >= 2)
        {
            goal2 = true;
        }
        if (GameInfo.GetComponent<GameInfo>().Pretre >= 1)
        {
            goal3 = true;
        }
        if (GameInfo.GetComponent<GameInfo>().Eglise >= 1)
        {
            goal4 = true;
        }
        if (GameInfo.GetComponent<GameInfo>().Barde >= 1)
        {
            goal5 = true;
        }
        if (GameInfo.GetComponent<GameInfo>().Aubergiste >= 1)
        {
            goal6 = true;
        }
        if (GameInfo.GetComponent<GameInfo>().Auberge >= 1)
        {
            goal7 = true;
        }
        if (profilOpen == false)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            scrollbar.SetActive(true);
            SpriteRenderer[] profils = GetComponentsInChildren<SpriteRenderer>();

            foreach (SpriteRenderer profil in profils)
            {
                if (profil.transform.position.y > -6 && profil.transform.position.y < 3)
                {
                    profil.GetComponent<SpriteRenderer>().enabled = true;
                    if (profil.GetComponentInChildren<TextMeshPro>())
                    {
                        profil.GetComponentInChildren<TextMeshPro>().enabled = true;
                    }
                    if (profil.GetComponentInChildren<SpriteRenderer>() && profil.name == "Square")
                    {
                        profil.GetComponentInChildren<SpriteRenderer>().enabled = false;
                    }
                    
                }
            }
            profilOpen = true;
            OnOpenProfil?.Invoke(goal1, goal2, goal3, goal4, goal5, goal6, goal7);
        }
        else if (profilOpen == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            scrollbar.SetActive(false);
            SpriteRenderer[] profils = GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer profil in profils)
            {
                profil.GetComponent<SpriteRenderer>().enabled = false;
                if (profil.GetComponentInChildren<TextMeshPro>())
                {
                    profil.GetComponentInChildren<TextMeshPro>().enabled = false;
                }
                if (profil.GetComponentInChildren<SpriteRenderer>() && profil.name == "Square")
                {
                    profil.GetComponentInChildren<SpriteRenderer>().enabled = false;
                }
            }
            profilOpen = false;
        }

    }
}
