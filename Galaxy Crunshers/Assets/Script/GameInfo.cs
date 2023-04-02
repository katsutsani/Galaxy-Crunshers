using UnityEditor.UIElements;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    [SerializeField] GameObject AllCharacter;
    [SerializeField] GameObject AllBuilding;


    public void compteCharacter()
    {
        foreach (Transform item in AllCharacter.GetComponentInChildren<Transform>())
        {
            Debug.Log("test");
        }
    }
}
