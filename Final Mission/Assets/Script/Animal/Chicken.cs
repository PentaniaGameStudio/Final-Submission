using UnityEngine;


public class Chicken : FarmAnimal
{
    protected override void Awake()
    {
        base.Awake();
        animalName = "Chicken";
        animalInt = 3;
    }

}
