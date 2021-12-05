using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behabs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider colOther)
    {
        if (colOther.gameObject.tag == "Player")
        {
            Collected();
        }
    }

    public virtual void Collected()
    {
        Debug.Log("Entra en Colelcted clase padre.");
    }
    
}
