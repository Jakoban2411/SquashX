using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockCount : MonoBehaviour {
    public int BlockNo = 0;
    public int PlayerScore = 0;
    public Text OnScreenText;
    [Range(0,100)] public int TimeScale = 1;
    // Use this for initialization
    void Start() {
        TimeScale = 1;
        PlayerScore = 0;
       
    }
    public void IncBlockNo()
    {
        BlockNo++;
    }
    public void DecBlock()
    {
        BlockNo--;
    }
    private void Awake()
    {
        int BlockCountNo = FindObjectsOfType<BlockCount>().Length;
        if (BlockCountNo > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }
    public void GameReset()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update ()
    {
        Time.timeScale = TimeScale;
    }
    public void AddToScore(int AddScore)
    {
        PlayerScore += AddScore;
        OnScreenText.text = PlayerScore.ToString();
    }
    public void SetTimeScale(int RelativeTime)
    {
        TimeScale = RelativeTime;
    }

}
