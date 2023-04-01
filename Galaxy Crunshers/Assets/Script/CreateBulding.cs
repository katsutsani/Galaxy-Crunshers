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

    void Start()
    {
        ClickableImage.Name += Clicked;
        ShowShop.removeName += RemoveName;
        m_isBuilding = false;
       
    }

    private void OnDestroy()
    {
        ClickableImage.Name -= Clicked;
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

    public void Clicked(string name)
    {
        if (CompareTag("AreaBuild") && !m_isBuilding && _buildingName != null)
        {
            switch (name)
            {
                case "Church":
                    m_isBuilding = true;
                    building = Instantiate(_building[0]);
                    break;
                case "Field":
                    m_isBuilding = true;
                    building = Instantiate(_building[1]);
                    break;
                case "Hostel":
                    m_isBuilding = true;
                    building = Instantiate(_building[2]);
                    break;

            }
            building.transform.SetParent(transform.parent);
            building.transform.position = transform.position;
            building.GetComponent<Building>()._actualArea = gameObject;
        }
    }
}
