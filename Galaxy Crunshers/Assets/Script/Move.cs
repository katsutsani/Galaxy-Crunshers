using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Speed;

    public int _delayDirection = 5;
    public int _delayStop = 2;
    private float x;
    private float y;

    // Start is called before the first frame update
    void Start()
    {
        ShowShop.reload += reload;
        StartCoroutine(Idle());
    }

    // Update is called once per frame

    public void reload()
    {
        StartCoroutine(Idle());
    }

    IEnumerator Idle()
    {
        yield return new WaitForSeconds(_delayStop);
        StartCoroutine(OnMove());
    }

    IEnumerator OnMove()
    {
        float count = 0;
        ChangeDir();
        while (count < _delayDirection)
        {
            count += Time.deltaTime;
            transform.position += Time.deltaTime * Speed * new Vector3(x, y);
            yield return null;
            
        }
        StartCoroutine(Idle());
    }

    void ChangeDir()
    {
        int direction = UnityEngine.Random.Range(0, 3);
        switch (direction)
        {
            case 0:
                x = -0.5f;
                y = -0.25f;
                break;
            case 1:
                x = 0.5f;
                y = 0.25f;
                break;
            case 2:
                x = -0.5f;
                y = 0.25f;
                break;
            case 3:
                x = 0.5f;
                y = -0.25f;
                break;
            default:
                break;
        }
    }
}
