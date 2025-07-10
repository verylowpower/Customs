using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public void ShowEnding()
    {
        string ending = GameProgressManager.instance.GetEnding();
        Debug.Log("Ending: " + ending);

        switch (ending)
        {
            case "Prison Ending":
                SceneManager.LoadScene("PrisonEnding");
                break;
            case "Promote Ending":
                SceneManager.LoadScene("PromoteEnding");
                break;
            case "Death Ending":
                SceneManager.LoadScene("DeathEnding");
                break;
            case "Schrodinger Ending":
                SceneManager.LoadScene("SchrodingerEnding");
                break;
            case "Ado Ending":
                SceneManager.LoadScene("AdoEnding");
                break;
            default:
                SceneManager.LoadScene("NormalEnding");
                break;
        }
    }
}
