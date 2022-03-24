using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chick : Chicken
{
    protected override void Awake()
    {
        base.Awake();
        animalName = "Chick";
        animalInt = 4;
    }
}
