using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject settingsPanel;





  



    //Pause panel wordt standard op niet active gezet zodat deze niet gelijk getoond wordt.
    void Start()
    {

        pausePanel.SetActive(false);
    }

    //Als escape wordt gedrukt wordt er gekeken of het Pause Panel actief is, als dit niet het geval is wordt de functie 
    //PauseGame() opgeroepen waardoor het spel wel op pauze gezet wordt. Als er dan weer op escape wordt gedrukt 
    //en het pauze menu staat nog open wordt de functie ContinueGame() opgeroepen waardoor het panel weer weggehaald wordt.
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeInHierarchy && !settingsPanel.activeInHierarchy)
            {
                PauseGame();
            }
            else
            {
                if (!settingsPanel.activeInHierarchy)
                {
                    ContinueGame();
                }
                
            } 
        }

    }

    //Game wordt op pauze gezet.
    private void PauseGame()
    {
        Cursor.visible = true;
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    
    //Game wordt weer aangezet en panel wordt weer wegehaald.
    private void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    //Scene wordt opnieuw geladen.
    public void RetryLevel()
    {
        Time.timeScale = 1;
        Invoke("RetryLevelTimer", 1f);
    }

    public void RetryLevelTimer()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    //Menu scene wordt geladen.
    public void GoToMenu()
    {
        Invoke("GoToMenuTimer", 1f);
        Time.timeScale = 1;
    }

    public void GoToMenuTimer()
    {
        SceneManager.LoadScene("SampleScene");
        
    }

    public void SettingsMenu()
    {
        if (!settingsPanel.activeInHierarchy)
        {
            settingsPanel.SetActive(true);
            pausePanel.SetActive(false);
        }
        else
        {
            settingsPanel.SetActive(false);
            pausePanel.SetActive(true);
        }
    }

    //Applicatie wordt gesloten.
    public void QuitGame()
    {
        Application.Quit();
    }

    /*//Volgende level wordt geladen.
    public void NextLevel()
    {
        Invoke("NextLevelTimer", 1f);
        Time.timeScale = 1;
        
        
    }

    public void NextLevelTimer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
*/
    
}

