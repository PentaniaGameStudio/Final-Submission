using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : Animal
{
    protected override void Awake()
    {
        base.Awake();
        animalName = "Crocodile";
        animalInt = 1;
    }

    override protected bool SpecieThings()
    {
        if (transform.position.y < -2.3f && transform.position.y > -3.5f)
            if (transform.position.x < 0.6f && transform.position.x > -0.6f)
            { AnimationLaunch(); return true; }

            else return false;
        else return false;
    }
}
