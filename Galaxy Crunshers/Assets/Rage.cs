using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage : MonoBehaviour
{
    public GameObject GameInfo;
    [SerializeField] private AudioClip enerve;
    private AudioSource enerveSource = null;
    bool Raged = false;
    // Start is called before the first frame update
    void Start()
    {
        GameInfo = GameObject.FindGameObjectWithTag("GameInfo");
    }

    // Update is called once per frame
    void Update()
    {
        enerveSource = GetComponent<AudioSource>();
        if (GameInfo.GetComponent<GameInfo>().Paysan > 1)
        {
            if (GameInfo.GetComponent<GameInfo>().Paysan > GameInfo.GetComponent<GameInfo>().Champ + 2)
            {
                if (Random.Range(0, 10) == 1)
                {
                    Rage[] array = GameInfo.GetComponent<GameInfo>()._allCharacter.GetComponentsInChildren<Rage>();
                    for (int i = GameInfo.GetComponent<GameInfo>().Paysan - (GameInfo.GetComponent<GameInfo>().Champ + 1); i >= 1; i--)
                    {
                        array[i].gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                        array[i].gameObject.GetComponent<Move>().Speed = 20;
                        array[i].gameObject.GetComponent<Rage>().Raged = true;
                    }
                    enerveSource.PlayOneShot(enerve);
                }

            }
        }
    }

    private void OnMouseDown()
    {
        if (Raged)
        {
            Destroy(gameObject);
            GameInfo.GetComponent<GameInfo>().Paysan--;
        }
    }
}
