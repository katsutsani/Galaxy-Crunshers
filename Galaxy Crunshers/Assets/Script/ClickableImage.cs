using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableImage : MonoBehaviour
{
    public static event Action<string> tagBuilding;
    public static event Action<string> tagCharacter;
    public static event Action<string> tagDiamond;



    public void GetClicked()
    {
        if (gameObject.tag.Contains("Building")) 
        {
            tagBuilding?.Invoke(gameObject.tag);
        }
        else if (gameObject.tag.Contains("Character"))
        {
            tagCharacter?.Invoke(gameObject.tag);
        }
        else if (gameObject.tag.Contains("Diamonds"))
        {
            tagDiamond?.Invoke(gameObject.tag);
        }
        
    }
}
