using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GridBrushBase;


public class Building : CreateBuilding
{
    public TextMeshPro m_text;
    public float m_endTimer;
    public GameObject m_actualArea;

    private bool _isArea;
    private bool _isChange;
    private Collider2D _pCol;


    void Start()
    {
        m_text.GetComponent<TextMeshPro>();
        _isArea = true;
        _isChange = false;
    }

    void Update()
    {
        SetTimer();
        
    }


    private void SetTimer()
    {
        if(!m_isBuilding)
        {
            float time = 0;
            time += Time.deltaTime;
            if(time < m_endTimer)
            {
                m_endTimer -= time;
                int minute = (int)m_endTimer / 60;
                int second = (int)m_endTimer % 60;
                if(second < 10)
                    m_text.text = minute.ToString() + ":" + "0" + second.ToString();
                else
                    m_text.text = minute.ToString() + ":" + second.ToString();
            }            
        }
    }
    


    void OnMouseDrag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePosition;

        if(m_actualArea != null && _isArea)
        {
            m_actualArea.GetComponent<CreateBuilding>().m_isBuilding = false;
            _isArea = false;
        }
    }

    private void OnMouseUp()
    {
        if (!_isChange)
        {
            transform.position = m_actualArea.transform.position;
            m_actualArea.GetComponent<CreateBuilding>().m_isBuilding = true;
            _isArea = true;

        }
        else
        {
            transform.position = _pCol.transform.position;
            _pCol.GetComponent<CreateBuilding>().m_isBuilding = true;
            m_actualArea.GetComponent<CreateBuilding>().m_isBuilding = false;
            m_actualArea = _pCol.gameObject;
            m_actualArea.GetComponent<CreateBuilding>().m_isBuilding = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "AreaBuild")
        {
            _pCol = collision;
            if (!_pCol.gameObject.GetComponent<CreateBuilding>().m_isBuilding)
            {
                _isChange = true;
            }
            else
            {
                _isChange = false;
                
            }
            _pCol.GetComponent<Collider2D>().enabled = true;

        }

    }

}



