using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HubManager : MonoBehaviour
{
    static HubManager _instanceHubManager;

    //HUB Menu
    public GameObject _hubMenuGO;
    //Hub Main Scene
    public GameObject _hubMainSceneGO;
    //Hub End Scene
    public GameObject _hubEndSceneGO;

    public Text _UIcurrentScore;
    public Text _UIMainSceneTotalScore;
    public Text _UIRecordScore;
    public Text _UIEndSceneTotalScore;

    public bool _fromMenu = false;

    public static HubManager HubManagerObject
    {
        get
        {
            return (_instanceHubManager);
        }
    }

    void Awake()
    {
        if (_instanceHubManager != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
        _instanceHubManager = this;        
    }

    private void Start()
    {
        GameManager.GameManagerObject.StartMenuScene();
    }

    //Populate MainScene text fields
    public void PopulateCurrentScore()
    {
        _UIcurrentScore.text = GameManager.GameManagerObject._currentScore.ToString() + " / " + GameManager.GameManagerObject._totalCoins.ToString();             
    }
    public void PopulateTotalScoreInMainScene()
    {
        _UIMainSceneTotalScore.text = GameManager.GameManagerObject._totalScore.ToString();
    }
    
    //Populate End Scene text fields
    public void PopulateTotalScoreInEndScene()
    {
        _UIEndSceneTotalScore.text = GameManager.GameManagerObject._totalScore.ToString();
    }
    public void PopulateRecordScore()
    {
        _UIRecordScore.text = GameManager.GameManagerObject._recordScore.ToString();
    }

    //Change UI Scenes
    public void SetMenuUI()
    {        
        _hubMainSceneGO.SetActive(false);
        _hubEndSceneGO.SetActive(false);
        _hubMenuGO.SetActive(true);
    }
    public void SetMainSceneUI()
    {
        _hubMenuGO.SetActive(false);     
        _hubEndSceneGO.SetActive(false);
        _hubMainSceneGO.SetActive(true);
    }
    public void SetEndSceneUI()
    {
        _hubMenuGO.SetActive(false);
        _hubMainSceneGO.SetActive(false);
        _hubEndSceneGO.SetActive(true);

        PopulateRecordScore();
        PopulateTotalScoreInEndScene();
    }

    //Events
    public void  OnPlayButtonPressed()
    {
        _fromMenu = true;
        GameManager.GameManagerObject.StartMainScene();              
    }
    public void OnBackToMenuButtonPressed()
    {
        GameManager.GameManagerObject.StartMenuScene();        
    }
    public void OnContinueButtonPressed()
    {
        SetEndSceneUI();
        GameManager.GameManagerObject.StartMenuScene();
    }

    public void StartMenuSceneUI()
    {
        SetMenuUI();       
    }

    public void StartMainSceneUI()
    {        
        SetMainSceneUI();
        PopulateCurrentScore();        
        PopulateTotalScoreInMainScene();
        
    }

    public void StartEndSceneUI()
    {
        SetEndSceneUI();
    }

}
