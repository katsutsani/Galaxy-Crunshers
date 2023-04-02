using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage : MonoBehaviour
{
    public GameObject GameInfo;
    // Start is called before the first frame update
    void Start()
    {
        GameInfo = GameObject.FindGameObjectWithTag("GameInfo");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameInfo.GetComponent<GameInfo>().Paysan >= GameInfo.GetComponent<GameInfo>().Champ+2)
        {
            //if (Random.Range(0, 10) == 1)
            //{
            //    Transform[] array = GameInfo.GetComponent<GameInfo>()._allCharacter.GetComponentsInChildren<Transform>();
            //    for (int i = GameInfo.GetComponent<GameInfo>().Paysan - GameInfo.GetComponent<GameInfo>().Champ; i >= 1; i--)
            //    {
            //        array[i].gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            //        array[i].gameObject.GetComponent<Move>().Speed = 20;
            //    }
            //}

        }
    }
}
