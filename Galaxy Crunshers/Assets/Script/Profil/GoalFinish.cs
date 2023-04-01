using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalFinish : MonoBehaviour
{
    [SerializeField] GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        OpenProfil.OnOpenProfil += OpenProfil_OnOpenProfil;
    }

    private void OpenProfil_OnOpenProfil(bool obj)
    {
        //if la quette est fini 
        button.SetActive(true);
    }

    private void OnDisable()
    {
        OpenProfil.OnOpenProfil -= OpenProfil_OnOpenProfil;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
