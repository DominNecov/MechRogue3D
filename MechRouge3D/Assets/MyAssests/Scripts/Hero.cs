using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Character
{
    
    // Start is called before the first frame update
    void Start()
    {
    }

    public override void Die()
    {
        base.Die();
        Destroy(this.gameObject);
    }

}
