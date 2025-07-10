using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameProgressManager : MonoBehaviour
{
    public static GameProgressManager instance;
    public Dictionary<EndingType, int> endingPoints = new();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
            foreach (EndingType type in System.Enum.GetValues(typeof(EndingType)))
                endingPoints[type] = 0;
        }
    }

    public void AddPoint(EndingType type, int amount = 1)
    {
        if (endingPoints.ContainsKey(type))
            endingPoints[type] += amount;
        else
            endingPoints[type] = amount;

        Debug.Log($"{type} +{amount} => {endingPoints[type]}");
    }

    public string GetEnding()
    {
        var max = endingPoints.OrderByDescending(e => e.Value).First();
        return max.Key.ToString() + " Ending";
    }
}
