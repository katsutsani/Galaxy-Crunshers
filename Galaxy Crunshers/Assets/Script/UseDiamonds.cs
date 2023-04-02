using System;
using UnityEngine;

public class UseDiamonds : MonoBehaviour
{
    [SerializeField] private GameObject m_Prefab;
    public static event Action<bool> StopTimer;
    private bool timerSet = false;

    private void OnMouseDown()
    {
        if (gameObject.tag == "Diamond")
        {
            timerSet = true;
            StopTimer?.Invoke(timerSet);
        }
    }
}
