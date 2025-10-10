using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerprefsCounter : MonoBehaviour
{
    [SerializeField] TMP_Text label;
    private const string COUNTER_PREF_NAME = "counter";
    private int counter;

    void Start()
    {
        counter = PlayerPrefs.GetInt(COUNTER_PREF_NAME); // Outputs 0 if no "counter" key matches
        label.SetText($"{counter}");
    }

    public void IncreaseCounter()
    {
        counter++;
        label.SetText($"{counter}");
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt(COUNTER_PREF_NAME, counter);
        PlayerPrefs.Save();
    }
}
