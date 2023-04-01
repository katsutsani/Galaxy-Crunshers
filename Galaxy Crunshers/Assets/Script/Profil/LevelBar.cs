using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    [SerializeField] Scrollbar lvl_bar;
    [SerializeField] private float lvl = 0f;
    private float max_lvl = 500f;

    private void Update()
    {
        // lvl_bar.size = 1 (0 xp)
        if (lvl > 0)
        {
            lvl_bar.size = lvl / max_lvl;
            lvl = 0;
        }
    }
}
