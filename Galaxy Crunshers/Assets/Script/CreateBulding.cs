using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreateBulding : MonoBehaviour
{
    public bool m_isBulding;
    public GameObject[] _bulding;
    [SerializeField] private ShowShop _showShop;
    private GameObject bulding;
    private string _buldingName;

    void Start()
    {
        ClickableImage.Name += Clicked;
        ShowShop.removeName += RemoveName;
        m_isBulding = false;
       
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
        _buldingName = null;
    }

    private void OnMouseDown()
    {
        if (CompareTag("AreaBuild") && !m_isBulding)
        {
            _buldingName = gameObject.name;
            _showShop.OpenMenu();
        }
    }

    public void Clicked(string name)
    {
        if (CompareTag("AreaBuild") && !m_isBulding && _buldingName != null)
        {
            switch (name)
            {
                case "Church":
                    m_isBulding = true;
                    bulding = Instantiate(_bulding[0]);
                    break;
                case "Field":
                    m_isBulding = true;
                    bulding = Instantiate(_bulding[1]);
                    break;
                case "Hostel":
                    m_isBulding = true;
                    bulding = Instantiate(_bulding[2]);
                    break;

            }
            bulding.transform.SetParent(transform.parent);
            bulding.transform.position = transform.position;
        }
    }
}
