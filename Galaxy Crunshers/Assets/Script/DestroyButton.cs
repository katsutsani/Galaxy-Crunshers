using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyButton : MonoBehaviour
{
    void Start()
    {
        UseDiamonds.Timer += UseDiamonds_Timer;
    }

    private void UseDiamonds_Timer(bool obj)
    {
        print(obj);
        if(obj)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);           
        }
    }

    void OnDisable()
    {
        UseDiamonds.Timer -= UseDiamonds_Timer;

    }
}
