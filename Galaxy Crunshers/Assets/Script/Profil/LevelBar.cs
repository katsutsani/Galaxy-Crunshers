using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    [SerializeField] Scrollbar lvl_bar;
    [SerializeField] private float lvl = 0f;
    private float plvl = 0f;
    private float max_lvl = 500f;

    private void Start()
    {
        GoalFinish.AddReputation += addReput;
        Building.UpgradeRep += Building_UpgradeRep;
    }

    private void Building_UpgradeRep(int obj)
    {
        plvl = obj;
        lvl += plvl;
    }

    public void addReput(int quantity)
    {
        lvl += quantity; 
    }
    private void Update()
    {
        if (lvl > 0)
        {
            lvl_bar.size = lvl / max_lvl;
            lvl = 0;
        }
    }
}
