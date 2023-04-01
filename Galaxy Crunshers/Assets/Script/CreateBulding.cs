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


    void Start()
    {
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
                    m_isBuilding = true;
                    building = Instantiate(_building[0]);
                    break;
                case "1Building":
                    m_isBuilding = true;
                    building = Instantiate(_building[1]);
                    break;
                case "2Building":
                    m_isBuilding = true;
                    building = Instantiate(_building[2]);
                    break;

            }
            building.transform.SetParent(m_allBuldings.transform);
            building.transform.position = transform.position;
            building.GetComponent<Building>().m_actualArea = gameObject;
        }
    }
}
