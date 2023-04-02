using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AddCharacter : MonoBehaviour
{

    private GameObject _instanceCharacter;
    [SerializeField] private GameObject[] _character;
    public static event Action<int> OnCharacterAdded;
    private int price;
    public static event Action CountChar;
    public GameObject GameInfo;

    // Start is called before the first frame update
    void Start()
    {
        GameInfo = GameObject.FindGameObjectWithTag("GameInfo");
        ClickableImage.tagCharacter += BuyCharacter;
    }

    private void OnDestroy()
    {
        ClickableImage.tagCharacter -= BuyCharacter;
    }

    public void BuyCharacter(string tag)
    {
        switch (tag)
        {
            case "0Character":
                if (GameInfo.GetComponent<GameInfo>().Paysan != 6)
                {
                    _instanceCharacter = Instantiate(_character[0]);
                    price = 100;
                    OnCharacterAdded?.Invoke(price);
                }
                
                break;
            case "1Character":
                if (GameInfo.GetComponent<GameInfo>().Pretre != 2)
                {
                    _instanceCharacter = Instantiate(_character[1]);
                    price = 100;
                    OnCharacterAdded?.Invoke(price);
                }
                break;
            case "2Character":
                if (GameInfo.GetComponent<GameInfo>().Pretre != 1)
                {
                    _instanceCharacter = Instantiate(_character[2]);
                    price = 100;
                    OnCharacterAdded?.Invoke(price);
                }
                break;
            case "3Character":
                if (GameInfo.GetComponent<GameInfo>().Aubergiste != 1)
                {
                    _instanceCharacter = Instantiate(_character[3]);
                    price = 100;
                    OnCharacterAdded?.Invoke(price);
                }
                break;

        }
        _instanceCharacter.transform.SetParent(transform);
        _instanceCharacter.transform.position = Vector3.zero;
        CountChar?.Invoke();

    }
}
