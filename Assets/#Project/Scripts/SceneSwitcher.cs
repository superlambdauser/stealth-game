using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string sceneName; // Possible to use indexes istead of names : less clear but cleaner. optimal for linear games

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SwitchScene);
    }

    public void SwitchScene()
    {
        GameManager.instance.score += 5;
        SceneManager.LoadScene(sceneName);
    }
}
