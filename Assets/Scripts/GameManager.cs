using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver = true;
    private SpawnManager spawnManager;
    public GameObject startPanel;
    public bool shieldActive=false;
    public GameObject shield;
    public GameObject gameOverPanel;
   
    void Start()
    {
        Time.timeScale = 0;
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        startPanel.SetActive(true);
    }
    void Update()
    {
        if (gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
                gameOver = false;
                spawnManager.StartSpawnRoutine();
            }
        }
        if(shieldActive==false)
        {
            shield.SetActive(false);
        }
    }

    public void OnClickPlay()
    {
        Time.timeScale = 1;
        gameOver = false;
        spawnManager.StartSpawnRoutine();
        startPanel.SetActive(false);
    }
    public void OnClickReplay()
    {
        SceneManager.LoadScene("SampleScene");
    }    
    public void OnClickClose()
    {
        Application.Quit();
    }
}
