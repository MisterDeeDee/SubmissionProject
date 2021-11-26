using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubManager : MonoBehaviour
{
    public void  OnPlayButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

}
