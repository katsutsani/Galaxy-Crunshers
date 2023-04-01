using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableImage : MonoBehaviour
{
    public static event Action<string> Name;

    public void GetClicked()
    {
        Name?.Invoke(gameObject.name);
    }
}
