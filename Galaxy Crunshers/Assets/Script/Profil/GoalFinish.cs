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
        if (goal1 == true)
        {
            button.SetActive(true);
        }
    }

    private void OnDisable()
    {
        OpenProfil.OnOpenProfil -= VisibleButton;
    }
}
