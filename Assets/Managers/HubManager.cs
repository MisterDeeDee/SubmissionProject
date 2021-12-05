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
    public GameObject hubMenuGO;
    //Hub Main Scene
    public GameObject hubMainSceneGO;
    //Hub End Scene
    public GameObject hubEndSceneGO;

    public Text UIcurrentScore;
    public Text UIMainSceneTotalScore;
    public Text UIRecordScore;
    public Text UIEndSceneTotalScore;

    public bool fromMenu = false;

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
        UIcurrentScore.text = GameManager.GameManagerObject.currentScore.ToString() + " / " + GameManager.GameManagerObject.totalCoins.ToString();             
    }
    public void PopulateTotalScoreInMainScene()
    {
        UIMainSceneTotalScore.text = GameManager.GameManagerObject.totalScore.ToString();
    }

    
    //Populate End Scene text fields
    public void PopulateTotalScoreInEndScene()
    {
        UIEndSceneTotalScore.text = GameManager.GameManagerObject.totalScore.ToString();
    }

    public void PopulateRecordScore()
    {
        UIRecordScore.text = GameManager.GameManagerObject.recordScore.ToString();
    }


    //Change UI Scenes
    public void SetMenuUI()
    {        
        hubMainSceneGO.SetActive(false);
        hubEndSceneGO.SetActive(false);
        hubMenuGO.SetActive(true);
    }
    
    public void SetMainSceneUI()
    {
        hubMenuGO.SetActive(false);     
        hubEndSceneGO.SetActive(false);
        hubMainSceneGO.SetActive(true);
    }
    
    public void SetEndSceneUI()
    {
        hubMenuGO.SetActive(false);
        hubMainSceneGO.SetActive(false);
        hubEndSceneGO.SetActive(true);

        PopulateRecordScore();
        PopulateTotalScoreInEndScene();
    }


    //Events
    public void  OnPlayButtonPressed()
    {
        fromMenu = true;
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

    public void OnQuitGameButtonPressed()
    {
        GameManager.GameManagerObject.GameQuit();
    }

    //Scene Starting
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
