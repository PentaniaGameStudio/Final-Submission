using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private TMPro.TextMeshProUGUI m_TextMeshPro;
    public int[] score = new int[6];
    private int owl = 0;
    private int crocodile = 1;
    private int cow = 2;
    private int chicken = 3;
    private int chick = 4;
    private int total = 5;


    private void Awake()
    {
        InstanceInitialize();
    }

    private void Start()
    {
        int[] basevalue = new int[6] {0,0,0,0,0,0};
        score = SaveManager.instance.Load<int[]>(basevalue, "score");
        m_TextMeshPro.text = "Total Score : " + score[total].ToString();
    }

    private void InstanceInitialize()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void AddPoints(int point, int index)
    {
        score[index] = point;
        score[total] = score[owl] + score[cow] + score[crocodile] + score[chicken] + score[chick];
        m_TextMeshPro.text = "Total Score : " + score[total].ToString();
    }
}
