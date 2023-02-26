using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isEnabled = false;
    public GameObject tutorialMenu;
    private bool isLookingTutorial = false;
    public GameObject quitMenu;
    private bool wantsToQuit = false;

    private void Start()
    {
        quitMenu.SetActive(false);
        pauseMenu.SetActive(false);
        tutorialMenu.SetActive(false);
    }

    public void TogglePauseMenu()
    {
        if(isEnabled)
        {
            isEnabled = false;
            pauseMenu.SetActive(false);
            Debug.Log("Pause menu not active");
            Time.timeScale = 1;
        }
        else if (!isEnabled)
        {
            isEnabled = true;
            pauseMenu.SetActive(true);
            Debug.Log("Pause menu active");
            Time.timeScale = 0;
        }
    }

    public void ToggleQuitMenu()
    {
        if(wantsToQuit)
        {
            wantsToQuit = false;
            quitMenu.SetActive(false);
        }
        else if (!wantsToQuit)
        {
            wantsToQuit = true;
            quitMenu.SetActive(true);
        }
    }

    public void Quit()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    public void Play()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToggleTutorial()
    {
        if (isLookingTutorial)
        {
            isLookingTutorial = false;
            tutorialMenu.SetActive(false);
            Debug.Log("Tutorial menu not active");
            Time.timeScale = 1;
        }
        else if (!isLookingTutorial)
        {
            isLookingTutorial = true;
            tutorialMenu.SetActive(true);
            Debug.Log("Tutorial menu active");
            Time.timeScale = 0;
        }
    }
}
