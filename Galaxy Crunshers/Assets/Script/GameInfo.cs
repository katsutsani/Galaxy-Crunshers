using System.Linq;
using UnityEditor.UIElements;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    [SerializeField] GameObject _allCharacter;
    [SerializeField] GameObject AllBuilding;

    public int Paysan =1;
    public int Pretre = 0;
    public int Jouvencelle = 0;
    public int Aubergiste= 0;

    public int Champ = 1;
    public int Auberge = 0;
    public int Eglise = 0;

    private void Start()
    {
        AddCharacter.CountChar += countCharacter;
        CreateBuilding.CountBuild += countBuilding;
    }
    public void countCharacter()
    {
        Paysan = 0;
        Pretre = 0;
        Jouvencelle = 0;
        Aubergiste = 0;
        if (_allCharacter != null)
        {
            Transform[] array = _allCharacter.GetComponentsInChildren<Transform>();
            for (int i = 1; i < array.Length; i++)
            {
                switch (array[i].gameObject.tag) 
                {
                    case "Paysan":
                        Paysan++;
                        break;
                    case "Pretre":
                        Pretre++;
                        break;
                    case "Jouvencelle":
                        Jouvencelle++;
                        break;
                    case "Aubergiste":
                        Aubergiste++;
                        break;
                }
            }
        }
    }

    public void countBuilding()
    {
        Champ = 0;
        Auberge = 0;
        Eglise = 0;
        if (_allCharacter != null)
        {
            Transform[] array = AllBuilding.GetComponentsInChildren<Transform>();
            for (int i = 1; i < array.Length; i++)
            {
                switch (array[i].gameObject.tag)
                {
                    case "Champ":
                        Champ++;
                        break;
                    case "Auberge":
                        Auberge++;
                        break;
                    case "Eglise":
                        Eglise++;
                        break;
                }
            }
        }
    }
}
