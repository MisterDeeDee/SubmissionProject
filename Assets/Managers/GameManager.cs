using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    public int _currentScore = 0;
    public int _totalScore = 0;
    public int _totalCoins = 2;
    public int _recordScore;

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
            _currentScore = value;

        }
        get
        {
            return (_currentScore);
        }
    }

    public void IncreaseTotalScore()
    {
        ++_totalScore;
        HubManager.HubManagerObject.PopulateTotalScoreInMainScene();
    }
    public void IncreaseScore()
    {
        ++_currentScore;                       
        HubManager.HubManagerObject.PopulateCurrentScore();
        IncreaseTotalScore();
    }
    public void ResetScore()
    {
        _currentScore = 0;        
    }
    public  void CheckScore()
    {
        if (_currentScore == _totalCoins)
        {
            HubManager.HubManagerObject._fromMenu = false;
            StartMainScene();
        }
        else return;

    }
    public void ResetTotalScore()
    {
        _totalScore = 0;
    }

    //Record Functions
    //Current Record
    public int CurrentRecord
    {
        set
        {
            _recordScore = value;
        }
        get
        {
            return (_recordScore);
        }
    }
    public void CheckRecord()
    {
        if (_totalScore > _recordScore)
        {
            _recordScore = _totalScore;
        }
    }

    //Config StartScene at load;
    public void StartMainScene()
    {
        ResetScore();   
        if (HubManager.HubManagerObject._fromMenu)
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
