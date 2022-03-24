using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmAnimal : Animal
{

    override protected bool SpecieThings()
    {
        if (transform.position.y < -2.3f && transform.position.y > -3.5f)
            if (transform.position.x < -5.4f && transform.position.x > -6.6f)
            { AnimationLaunch(); return true; }

            else return false;
        else return false;
    }
}
