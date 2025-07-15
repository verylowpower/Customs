using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartButton()
    {
        if (GameProgressManager.instance != null)
            GameProgressManager.instance.ResetProgress(); 

        SceneManager.LoadSceneAsync(1); 
        Time.timeScale = 1f;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);

        if (DialogueManager.instance != null)
            DialogueManager.instance.dialoguePanel.SetActive(false);

        if (UIManager.instance != null && UIManager.instance.dayText != null)
            UIManager.instance.dayText.gameObject.SetActive(false);
    }

    public void ResumeButton()
    {
        SceneManager.UnloadSceneAsync("Menu");
        Pause.instance.isPaused = false;
        Pause.instance.pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
