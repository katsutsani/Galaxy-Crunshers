using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRagedPaysan : MonoBehaviour
{

    [SerializeField] GameObject RagePaysan;
    [SerializeField] GameObject _allCharacter;
    private GameObject RagedPaysan;
    // Start is called before the first frame update
    void Start()
    {
        _allCharacter = GameObject.FindGameObjectWithTag("AllCharacters"); ;
    }
    private void OnMouseDown()
    {
        RagedPaysan = Instantiate(RagePaysan);
        RagedPaysan.transform.position = new Vector3(8, -3);
        RagedPaysan.transform.SetParent(_allCharacter.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
