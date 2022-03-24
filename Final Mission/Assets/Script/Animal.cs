using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Animal : MonoBehaviour
{
    [SerializeField] protected string animalName = "Unknow";
    [SerializeField] protected AudioSource mainCamera;
    [SerializeField] protected AudioClip animalClip;
    [SerializeField] protected Vector2 animalPos;
    [SerializeField] protected TMPro.TextMeshProUGUI animal_text;
    [SerializeField] protected Canvas myCanvas;
    protected string base_text = "Animal Name : ";
    [SerializeField] protected GameObject firework;
    protected int animalInt;

    protected void OnMouseDown()
    {
        GetName();
        MakeSound();
    }

    protected void OnMouseDrag()
    {
        Move();
    }

    protected void OnMouseUp()
    {
        if (SpecieThings()==true)
        {
            SpecieThings();
            ScoreManager.instance.AddPoints(1, animalInt);
        } else ScoreManager.instance.AddPoints(0, animalInt);
        SaveManager.instance.Save<Vector3>(transform.position, animalName);
    }

    abstract protected bool SpecieThings();

    protected void AnimationLaunch()
    {
        GameObject clonefirework = Instantiate(firework, transform.position, Quaternion.identity);
        Destroy(clonefirework, 5f);
    }
    protected void GetName()
    {
        animal_text.text = base_text + animalName;
    }

    protected void MakeSound()
    {
        if (!mainCamera.isPlaying) mainCamera.PlayOneShot(animalClip);
    }

    protected virtual void Awake()
    {
        animal_text = GameObject.Find("Text Animal").GetComponent<TMPro.TextMeshProUGUI>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        myCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        firework = GameObject.Find("Firework");
    }

    protected void Start()
    {
        Vector3 test = new Vector3(0,0,0);
        Vector3 loaded = SaveManager.instance.Load<Vector3>(transform.position, animalName);
        if (loaded != test) transform.position = loaded;
    }
    protected void Move()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
    }
}
