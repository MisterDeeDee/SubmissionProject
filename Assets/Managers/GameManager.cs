using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 

    [SerializeField]
    public int currentScore = 0;
    public int totalScore = 0;
    public int totalCoins = 2;
    public int recordScore;

    //GamManager Singleton
    static GameManager _instanceGameManager;
    public static GameManager GameManagerObject
    {
        get 
        {
            return _instanceGameManager; 
        }
    }    

    void Awake()
    {
        if (_instanceGameManager != null)    
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
        _instanceGameManager = this;

        //TODO - Repasar eventos para el SceneManager 
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        SaveData.LoadData();
    }

    //Score functions
    //Current Score
    public int CurrentScore
    {
        set
        {
            currentScore = value;

        }
        get
        {
            return (currentScore);
        }
    }

    public void IncreaseTotalScore()
    {
        ++totalScore;
        HubManager.HubManagerObject.PopulateTotalScoreInMainScene();
    }
    
    public void IncreaseScore()
    {
        ++currentScore;                       
        HubManager.HubManagerObject.PopulateCurrentScore();
        IncreaseTotalScore();
    }
    
    public void ResetScore()
    {
        currentScore = 0;        
    }
    
    public  void CheckScore()
    {
        if (currentScore == totalCoins)
        {
            HubManager.HubManagerObject.fromMenu = false;
            StartMainScene();
        }
        else return;

    }
    
    public void ResetTotalScore()
    {
        totalScore = 0;
    }

    //Record Functions
    //Current Record
    
    public int CurrentRecord
    {
        set
        {
            recordScore = value;
        }
        get
        {
            return (recordScore);
        }
    }
    
    public void CheckRecord()
    {
        if (totalScore > recordScore)
        {
            recordScore = totalScore;
        }
    }

    
    //Config StartScene at load;
    //...
    public void StartMainScene()
    {
        ResetScore();   
        if (HubManager.HubManagerObject.fromMenu)
        {
            ResetTotalScore();
        }
        HubManager.HubManagerObject.StartMainSceneUI();
        SceneManager.LoadScene(1);
    }
        
    public void StartEndScene()
    {
        CheckRecord();
        HubManager.HubManagerObject.StartEndSceneUI();
        SceneManager.LoadScene(2);       
    }

    public void StartMenuScene()
    {
        ResetScore();
        ResetTotalScore();
        HubManager.HubManagerObject.StartMenuSceneUI();
        SceneManager.LoadScene(0);
    }  

    
    //Game Events    
    //
    public void PlayerKilled()
    {
        StartEndScene();
    }

    public void CoinCollected()
    {
        IncreaseScore();
        CheckScore();
    }
    
    public void GameQuit()
    {
        SaveData.SaveGameData();
        Debug.Log("Saved data path: " + SaveData.path);
        Debug.Log("********GAME QUIT**********");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
