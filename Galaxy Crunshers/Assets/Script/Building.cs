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
    public Gold m_scriptGold;


    private bool _isArea;
    private bool _isChange;
    private Collider2D _pCol;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] _newSprite;
    private int _goldSave;
    private int _reputSave;
    [SerializeField] private int _goldLoad;
    [SerializeField] private int _reputLoad;
    private bool _isMouseDown;


    public static event Action<int> DimondPrice;
    public ParticleSystem _particle;
    public ParticleSystem _particleGold;
    public static event Action<int> UpgradeGold;
    public static event Action<int> UpgradeRep;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _particleGold = GetComponent<ParticleSystem>();
        _spriteRenderer.color = Color.white;
        _isMouseDown= false;
    }

    void Start()
    {
        GameInfo = GameObject.FindGameObjectWithTag("GameInfo");
        m_text.GetComponent<TextMeshPro>();
        _isArea = true;
        _isChange = false;
        UseDiamonds.StopTimer += UseDiamonds_StopTimer;
        _goldSave = 0;
        
    }

    public void UseDiamonds_StopTimer(bool obj)
    {
        if (obj == true)
        {
            float timerDiamond = m_endTimer;
            int priceDiamond = Mathf.Max(1, (int)timerDiamond / 60 * 2);
            DimondPrice?.Invoke(priceDiamond);
            m_endTimer = 0;
            _particle.Play();

        }
    }
    private void OnDisable()
    {
        UseDiamonds.StopTimer -= UseDiamonds_StopTimer;
    }

    void Update()
    {
        
        SetTimer();
        if (m_endTimer == 0)
        {
            _spriteRenderer.sprite = _newSprite[1];
            StartCoroutine(GainGold());
            StartCoroutine(GainReput());
            Destroy(m_text);
            if (_isMouseDown)
            {
                UpgradeGold?.Invoke(_goldSave);
                UpgradeRep?.Invoke(_reputSave);
                _isMouseDown = false;
                _goldSave = 0;
                _reputSave = 0;
                _particleGold.Play();
            }
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
                    StartCoroutine(GainGold());
                    StartCoroutine(GainReput());
                    if (_isMouseDown)
                    {
                        UpgradeGold?.Invoke(_goldSave);
                        UpgradeRep?.Invoke(_reputSave);
                        _isMouseDown = false;
                        _goldSave = 0;
                        _reputSave = 0;
                        _particleGold.Play();
                    }
                }
            }
        }    
    }


    IEnumerator GainGold() 
    {
        yield return new WaitForSeconds(60);
        switch (tag)
        {
            case "Champ":
                _goldLoad *= GameInfo.GetComponent<GameInfo>().Paysan;
                _goldSave += _goldLoad;
                StopAllCoroutines();
                StartCoroutine(GainGold());
                break;

            case "Auberge":
                _goldLoad *= GameInfo.GetComponent<GameInfo>().Aubergiste;
                _goldSave += _goldLoad;
                StopAllCoroutines();
                StartCoroutine(GainGold());
                break;

            case "Eglise":
                _goldLoad *= GameInfo.GetComponent<GameInfo>().Pretre;
                _goldSave += _goldLoad;
                StopAllCoroutines();
                StartCoroutine(GainGold());
                break;
        }
        
    }

    IEnumerator GainReput()
    {
        yield return new WaitForSeconds(60);
        switch (tag)
        {
            case "Champ":
                _reputLoad *= GameInfo.GetComponent<GameInfo>().Paysan;
                _reputSave += _reputLoad;
                StopAllCoroutines();
                StartCoroutine(GainReput());
                break;

            case "Auberge":
                _reputLoad *= GameInfo.GetComponent<GameInfo>().Aubergiste;
                _reputSave += _reputLoad;
                StopAllCoroutines();
                StartCoroutine(GainReput());
                break;

            case "Eglise":
                _reputLoad *= GameInfo.GetComponent<GameInfo>().Pretre;
                _reputSave += _reputLoad;
                StopAllCoroutines();
                StartCoroutine(GainReput());
                break;
        }
    }


    void OnMouseDrag()
    {

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePosition;

        if (m_actualArea != null && _isArea)
        {
            m_actualArea.GetComponent<CreateBuilding>().m_isBuilding = false;
            _isArea = false;
        }

    }

    private void OnMouseDown()
    {
        _isMouseDown = true;
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



