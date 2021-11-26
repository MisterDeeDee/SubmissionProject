using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehab : MonoBehaviour
{

    public float RotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateCoin();
    }

    private void RotateCoin()
    {
        transform.Rotate(Vector3.left * (RotationSpeed * Time.deltaTime));
    }

    private void CoinCollected(Collider colOther)
    {
        Debug.Log("Collision con: " + colOther.gameObject.tag);
    }

    private void OnTriggerEnter(Collider colOther)
    {
        CoinCollected(colOther);

        if (colOther.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
