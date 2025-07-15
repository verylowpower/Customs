using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public static EndingManager instance;

    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    public void ShowEnding()
    {
        EndingType ending = GameProgressManager.instance.GetEndingType();
        Debug.Log("Ending: " + ending);

        string sceneToLoad;

        switch (ending)
        {
            case EndingType.Prison:
                sceneToLoad = "PrisonEnding";
                break;
            case EndingType.Promote:
                sceneToLoad = "PromoteEnding";
                break;
            case EndingType.Death:
                sceneToLoad = "DeathEnding";
                break;
            case EndingType.Schrodinger:
                sceneToLoad = "SchrodingerEnding";
                break;
            case EndingType.Ado:
                sceneToLoad = "AdoEnding";
                break;
            default:
                sceneToLoad = "NormalEnding";
                break;
        }

        StartCoroutine(LoadEndingAndReturn(sceneToLoad));
    }

    private System.Collections.IEnumerator LoadEndingAndReturn(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Menu");
    }
}
