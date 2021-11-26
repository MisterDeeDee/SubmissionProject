using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    public int _currentScore = 0;

    int _currentRound;
    int _recordRound;

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
    public void IncreaseScore()
    {
        _currentScore = _currentScore + 1;
        HubManager.HubManagerObject.UpdateCurrentScore();

    }
    public void ResetScore()
    {
        _currentScore = 0;
    }

    //Current Round
    public int CurrentRound
    {
        set
        {
            _currentRound = value;

        }
        get
        {
            return (_currentRound);
        }
    }
    public void IncreaseRound()
    {
        _currentRound += _currentRound;
    }

    //Record Round
    public int RecordRound
    {
        set
        {
            _recordRound = value;

        }
        get
        {
            return (_recordRound);
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
    }
}
