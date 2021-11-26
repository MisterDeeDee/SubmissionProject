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

    private void Start()
    {
        _hubMenuGO.SetActive(true);
        _hubMainSceneGO.SetActive(false);
    }

    public Text _UIcurrentScore;

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
    public void UpdateCurrentScore()
    {
        _UIcurrentScore.text = GameManager.GameManagerObject._currentScore.ToString();            
    }

    public void  OnPlayButtonPressed()
    {
        GameManager.GameManagerObject.ResetScore();
        SceneManager.LoadScene(1);
        _hubMenuGO.SetActive(false);
        _hubMainSceneGO.SetActive(true);
        UpdateCurrentScore();
    }

    public void OnBackToMenuButtonPressed()
    {
        SceneManager.LoadScene(0);
        _hubMenuGO.SetActive(true);
        _hubMainSceneGO.SetActive(false);
    }
}
