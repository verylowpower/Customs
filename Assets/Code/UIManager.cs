using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI dayText;
    public TextMeshProUGUI pointText;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        
        if (DayManager.instance == null) return;

        dayText.text = "Day " + (DayManager.instance.currentDay + 1);
        // pointText.text = "Point: " + GameProgressManager.instance.totalPoints;
    }
}
