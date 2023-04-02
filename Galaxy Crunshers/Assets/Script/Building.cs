using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Build;
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
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] _newSprite;
    public static event Action<int> DimondPrice;
    [SerializeField] private ParticleSystem _particle;
    public bool Collect = false;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = Color.white;
    }

    void Start()
    {
        GameInfo = GameObject.FindGameObjectWithTag("GameInfo");
        m_text.GetComponent<TextMeshPro>();
        _isArea = true;
        _isChange = false;
        UseDiamonds.StopTimer += UseDiamonds_StopTimer;
    }

    public void UseDiamonds_StopTimer(bool obj)
    {
        if (obj == true)
        {
            float timerDiamond = m_endTimer;
            int priceDiamond = Mathf.Max(1, (int)timerDiamond / 60 * 2);
            DimondPrice?.Invoke(priceDiamond);
            m_endTimer = 0;
        }
    }
    private void OnDisable()
    {
        UseDiamonds.StopTimer -= UseDiamonds_StopTimer;
    }

    void Update()
    {



        SetTimer();
        if (m_endTimer <= 0.1)
        {
            _spriteRenderer.sprite = _newSprite[1];
            Destroy(m_text);
            _particle.Play();
        }
    }


    private void SetTimer()
    {
        if (!m_isBuilding)
        {
            float time = 0;
            time += Time.deltaTime;
            if (time < m_endTimer)
            {
                _spriteRenderer.sprite = _newSprite[0];
                m_endTimer -= time;
                //m_endTimer = 0;
                int minute = (int)m_endTimer / 60;
                int second = (int)m_endTimer % 60;
                if (second < 10)
                    m_text.text = minute.ToString() + ":" + "0" + second.ToString();
                else
                    m_text.text = minute.ToString() + ":" + second.ToString();
                if (m_endTimer <= 0.01)
                {
                    _spriteRenderer.sprite = _newSprite[1];
                    Destroy(m_text);
                    _particle.Play();
                }
            }
        }
        if (!Collect && m_isBuilding)
        {
            float time = 0;
            time += Time.deltaTime;
            if (time < 10)
            {
                m_endTimer -= time;
                //m_endTimer = 0;
                int minute = (int)m_endTimer / 60;
                int second = (int)m_endTimer % 60;
                if (second < 10)
                    m_text.text = minute.ToString() + ":" + "0" + second.ToString();
                else
                    m_text.text = minute.ToString() + ":" + second.ToString();
                if (m_endTimer <= 0.01)
                {
                    Debug.Log("recolt");
                    Collect = true;
                    m_endTimer = 10;
                }
            }
        }
    }



    void OnMouseDrag()
    {
        if (!Collect)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = mousePosition;

            if (m_actualArea != null && _isArea)
            {
                m_actualArea.GetComponent<CreateBuilding>().m_isBuilding = false;
                _isArea = false;
            }
        }

    }

    private void OnMouseDown()
    {
        if (Collect)
        {
            int nbChamp = GameInfo.GetComponent<GameInfo>().Champ;
            int nbPaysan = GameInfo.GetComponent<GameInfo>().Paysan;
            Debug.Log("test");
            if (nbChamp == 1)
            {
                if (nbPaysan == 1)
                {
                    //add 5 per min
                }
                else if (nbPaysan == 2)
                {
                    //add 10 per min
                }
            }
            if (nbChamp == 2)
            {
                if (nbPaysan == 1)
                {
                    //add 5 per min
                }
                else if (nbPaysan == 2)
                {
                    //add 10 per min
                }
                else if (nbPaysan == 3)
                {
                    //add 15 per min
                }
                else if (nbPaysan == 4)
                {
                    //add 20 per min
                }
            }
            Collect = false;
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
        if (collision.tag == "AreaBuild")
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



