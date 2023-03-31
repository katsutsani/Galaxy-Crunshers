using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreateBulding : MonoBehaviour
{
    public bool m_isBulding;
    public GameObject[] _bulding;

    private GameObject bulding;

    void Start()
    {
        m_isBulding = false;
       
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {

        if (CompareTag("AreaBuild") && !m_isBulding)
        {
            int rand = UnityEngine.Random.Range(0, 2);
            switch(rand)
            {
                case 0:
                    m_isBulding = true;
                    bulding = Instantiate(_bulding[0]);
                    break;
                case 1:
                    m_isBulding = true;
                    bulding = Instantiate(_bulding[1]);
                    break;
                case 2:
                    m_isBulding = true;
                    bulding = Instantiate(_bulding[2]);

                    break;

            }
            bulding.transform.position = transform.position;
        }
    }
}
