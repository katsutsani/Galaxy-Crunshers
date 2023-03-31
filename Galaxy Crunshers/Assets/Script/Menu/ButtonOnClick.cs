using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOnClick : MonoBehaviour
{
    [SerializeField] private bool level1 = true;
    [SerializeField] private bool level2 = false;
    [SerializeField] private bool level3 = false;
    [SerializeField] private bool level4 = false;
    public void OnClickButton()
    {
        if (level1 == true && gameObject.name == "Button")
        {
        SceneManager.LoadScene(0);
        }
        if (level2 == true && gameObject.name == "Button (1)")
        {
            SceneManager.LoadScene(2);
        }
        if (level3 == true && gameObject.name == "Button (2)")
        {
            SceneManager.LoadScene(2);
        }
        if (level4 == true && gameObject.name == "Button (3)")
        {
            SceneManager.LoadScene(3);
        }
    }
}
