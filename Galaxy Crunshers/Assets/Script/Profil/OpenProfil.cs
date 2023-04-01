using System;
using UnityEngine;
using UnityEngine.Profiling;

public class OpenProfil : MonoBehaviour
{
    [SerializeField] private bool profilOpen = false;
    public static event Action<bool> OnOpenProfil;

    public void OpenProfilPlayer()
    {
        
        if (profilOpen == false)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            SpriteRenderer[] profils = GetComponentsInChildren<SpriteRenderer>();

            foreach (SpriteRenderer profil in profils)
            {
                profil.GetComponent<SpriteRenderer>().enabled = true;
            }
            if(profilOpen == false)
            {
                OnOpenProfil?.Invoke(profilOpen);
            }
            profilOpen = true;
        }
        else if (profilOpen == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            SpriteRenderer[] profils = GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer profil in profils)
            {
                profil.GetComponent<SpriteRenderer>().enabled = false;
            }
            profilOpen = false;
        }

    }
}
