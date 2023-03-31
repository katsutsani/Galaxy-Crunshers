using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class Bulding : CreateBulding
{

    public TextMeshPro m_text;
    public float m_endTimer;


    void Start()
    {

        m_text.GetComponent<TextMeshPro>();
    }

    void Update()
    {
        SetTimer();
    }


    private void SetTimer()
    {
        if(!m_isBulding)
        {
            float time = 0;
            time += Time.deltaTime;
            if(time < m_endTimer)
            {
                m_endTimer -= time;
                int minute = (int)m_endTimer / 60;
                int second = (int)m_endTimer % 60;
                m_text.text = minute.ToString() + ":" + second.ToString();
            }            
        }
    }
}



