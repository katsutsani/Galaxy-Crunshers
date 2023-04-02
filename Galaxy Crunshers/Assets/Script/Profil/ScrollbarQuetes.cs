using System;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarQuetes : MonoBehaviour
{
    [SerializeField] GameObject scrollbar;
    private float scroll = 0;
    private bool first = true;
    private bool second = false;

    public void ScrollBar()
    {
        scroll = scrollbar.GetComponent<Scrollbar>().value;

        SpriteRenderer[] profils = GetComponentsInChildren<SpriteRenderer>();
        if (scroll >= 0.5 && first == true && second == false)
        {
            foreach (SpriteRenderer profil in profils)
            {
                profil.transform.position += new Vector3(0, 0.5f * 2, 0);
                if (profil.name == "Quete_name5")
                {
                    profil.GetComponent<SpriteRenderer>().enabled = true;
                    if (profil.GetComponentInChildren<TextMeshPro>())
                    {
                        profil.GetComponentInChildren<TextMeshPro>().enabled = true;
                    }
                    if (profil.GetComponentInChildren<SpriteRenderer>() && profil.name == "Square")
                    {
                        profil.GetComponentInChildren<SpriteRenderer>().enabled = true;
                    }
                }
                if (profil.name == "Quete_name")
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
            }
            first = false;
            second = true;
        }
        if (scroll >= 0.7 && second == true && first == false)
        {
            foreach (SpriteRenderer profil in profils)
            {
                profil.transform.position += new Vector3(0, 1 * 1f, 0);
                if (profil.name == "Quete_name6")
                {
                    profil.GetComponent<SpriteRenderer>().enabled = true;
                    if (profil.GetComponentInChildren<TextMeshPro>())
                    {
                        profil.GetComponentInChildren<TextMeshPro>().enabled = true;
                    }
                    if (profil.GetComponentInChildren<SpriteRenderer>() && profil.name == "Square")
                    {
                        profil.GetComponentInChildren<SpriteRenderer>().enabled = true;
                    }
                }
                if (profil.name == "Quete_name1")
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
            }
            first = false;
            second = false;
        }

        if (scroll <= 0.5 && first == false && second == true)
        {
            foreach (SpriteRenderer profil in profils)
            {
                profil.transform.position -= new Vector3(0, 0.5f * 2, 0);
                if (profil.name == "Quete_name")
                {
                    profil.GetComponent<SpriteRenderer>().enabled = true;
                    if (profil.GetComponentInChildren<TextMeshPro>())
                    {
                        profil.GetComponentInChildren<TextMeshPro>().enabled = true;
                    }
                    if (profil.GetComponentInChildren<SpriteRenderer>() && profil.name == "Square")
                    {
                        profil.GetComponentInChildren<SpriteRenderer>().enabled = true;
                    }

                }
                if (profil.name == "Quete_name5")
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
            }
            first = true;
            second = false;
        }
        if (scroll <= 0.7 && second == false && first == false)
        {
            foreach (SpriteRenderer profil in profils)
            {
                profil.transform.position -= new Vector3(0, 1 * 1f, 0);
                if (profil.name == "Quete_name1")
                {
                    profil.GetComponent<SpriteRenderer>().enabled = true;
                    if (profil.GetComponentInChildren<TextMeshPro>())
                    {
                        profil.GetComponentInChildren<TextMeshPro>().enabled = true;
                    }
                    if (profil.GetComponentInChildren<SpriteRenderer>() && profil.name == "Square")
                    {
                        profil.GetComponentInChildren<SpriteRenderer>().enabled = true;
                    }

                }
                if (profil.name == "Quete_name6")
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
            }
            first = false;
            second = true;
        }
    }
}
