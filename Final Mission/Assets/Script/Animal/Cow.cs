using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : FarmAnimal
{    protected override void Awake()
    {
        base.Awake();
        animalName = "Cow";
        animalInt = 2;
    }
}
