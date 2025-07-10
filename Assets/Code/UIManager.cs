using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI dayText;
    public TextMeshProUGUI pointText;

    void Update()
    {
        dayText.text = "Day " + (DayManager.instance.currentDay + 1);
        //pointText.text = "Point: " + GameProgressManager.instance.totalPoints;
    }
}
