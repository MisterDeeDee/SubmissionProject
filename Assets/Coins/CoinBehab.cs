using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehab : Behabs
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

    
    public override void Collected()
    {
        GameManager.GameManagerObject.CoinCollected();
        Destroy(this.gameObject);
        base.Collected();
    }

    
}
