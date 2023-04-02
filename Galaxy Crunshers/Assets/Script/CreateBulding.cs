using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreateBuilding : MonoBehaviour
{
    public bool m_isBuilding;
    public GameObject[] _building;
    [SerializeField] private ShowShop _showShop;
    private GameObject building;
    private string _buildingName;
    public GameObject m_allBuldings;
    public static event Action CountBuild;
    public GameObject GameInfo;


    void Start()
    {
        GameInfo = GameObject.FindGameObjectWithTag("GameInfo");
        ClickableImage.tagBuilding += Clicked;
        ShowShop.removeName += RemoveName;
        m_isBuilding = false;
       
    }

    private void OnDestroy()
    {
        ClickableImage.tagBuilding -= Clicked;
        ShowShop.removeName -= RemoveName;
    }

    void Update()
    {
        
    }

    public void RemoveName()
    {
        _buildingName = null;
    }

    private void OnMouseDown()
    {
        if (CompareTag("AreaBuild") && !m_isBuilding)
        {
            _buildingName = gameObject.name;
            _showShop.OpenMenu();
            _showShop.ShowBuildingsShopOnArea();
        }
    }

    public void Clicked(string tag)
    {
        if (CompareTag("AreaBuild") && !m_isBuilding && _buildingName != null)
        {
            switch (tag)
            {
                case "0Building":
                    if(GameInfo.GetComponent<GameInfo>().Eglise != 1)
                    {
                        m_isBuilding = true;
                        building = Instantiate(_building[0]);
                    }
                    break;
                case "1Building":
                    if (GameInfo.GetComponent<GameInfo>().Champ != 2)
                    {
                        m_isBuilding = true;
                        building = Instantiate(_building[1]);
                    }
                    break;
                case "2Building":
                    if (GameInfo.GetComponent<GameInfo>().Auberge != 1)
                    {
                        m_isBuilding = true;
                        building = Instantiate(_building[2]);
                    }
                    break;

            }
            if(building!= null)
            {
                building.transform.SetParent(m_allBuldings.transform);
                building.transform.position = transform.position;
                building.GetComponent<Building>().m_actualArea = gameObject;
                CountBuild?.Invoke();
            }
           
        }
    }
}
