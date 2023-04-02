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

    // Start is called before the first frame update
    void Start()
    {
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
                _instanceCharacter = Instantiate(_character[0]);
                price = 100;
                OnCharacterAdded?.Invoke(price);
                break;
            case "1Character":
                _instanceCharacter = Instantiate(_character[1]);
                price = 100;
                OnCharacterAdded?.Invoke(price);
                break;
            case "2Character":
                _instanceCharacter = Instantiate(_character[2]);
                price = 100;
                OnCharacterAdded?.Invoke(price);
                break;
            case "3Character":
                _instanceCharacter = Instantiate(_character[3]);
                price = 100;
                OnCharacterAdded?.Invoke(price);
                break;

        }
        _instanceCharacter.transform.SetParent(transform);
        _instanceCharacter.transform.position = Vector3.zero;

    }
}
