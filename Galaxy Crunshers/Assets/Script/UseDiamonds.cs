using System;
using UnityEngine;

public class UseDiamonds : MonoBehaviour
{
    [SerializeField] private GameObject m_Prefab;
    public static event Action<bool> StopTimer;
    private bool timerSet = false;
    private Building _buildScript;
    [SerializeField] public SpriteRenderer _spriteR;

    public static event Action<bool> Timer;

    private void Start()
    {
        _buildScript = GetComponent<Building>();
    }

    private void OnMouseDown()
    {
        if (gameObject.tag == "Diamond")
        {
            timerSet = true;
            Timer?.Invoke(timerSet);
            StopTimer?.Invoke(timerSet);
            //_buildScript._particle.Play();
        }
    }
}
