using UnityEngine;
using UnityEngine.Profiling;

public class OpenProfil : MonoBehaviour
{
    [SerializeField] private bool profilOpen = false;
    /*[SerializeField] private GameObject profil;*/

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
