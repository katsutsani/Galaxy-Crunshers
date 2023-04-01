using UnityEngine;

public class GoalFinish : MonoBehaviour
{
    [SerializeField] GameObject button;

    void Start()
    {
        OpenProfil.OnOpenProfil += VisibleButton;
    }

    private void VisibleButton(bool goal1, bool goal2, bool goal3, bool goal4, bool goal5, bool goal6, bool goal7)
    {
        //mettre les quete fini et passer a true le goal
        if (goal1 == true)
        {
            button.SetActive(true);
        }
        if (goal2 == true)
        {
            button.SetActive(true);
        }
        if (goal3 == true)
        {
            button.SetActive(true);
        }
        if (goal4 == true)
        {
            button.SetActive(true);
        }
        if (goal5 == true)
        {
            button.SetActive(true);
        }
        if (goal6 == true)
        {
            button.SetActive(true);
        }
        if (goal7 == true)
        {
            button.SetActive(true);
        }
    }

    private void OnDisable()
    {
        OpenProfil.OnOpenProfil -= VisibleButton;
    }
}
