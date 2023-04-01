using System;
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
    public static event Action<bool, bool, bool, bool, bool, bool, bool> OnOpenProfil;

    public void OpenProfilPlayer()
    {
        if (profilOpen == false)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            scrollbar.SetActive(true);
            SpriteRenderer[] profils = GetComponentsInChildren<SpriteRenderer>();

            foreach (SpriteRenderer profil in profils)
            {
                if (profil.transform.position.y > -9 && profil.transform.position.y < -2)
                {
                    profil.GetComponent<SpriteRenderer>().enabled = true;
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
            }
            profilOpen = false;
        }

    }
}
