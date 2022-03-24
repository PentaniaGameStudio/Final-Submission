using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : Animal
{
    protected override void Awake()
    {
        base.Awake();
        animalName = "Owl";
        animalInt = 0;
    }

    override protected bool SpecieThings()
    {
        if (transform.position.y < -2.3f && transform.position.y > -3.5f)
            if (transform.position.x < 6.6f && transform.position.x > 5.4f)
            { AnimationLaunch(); return true; }

        else return false;
        else return false;

    }
}
