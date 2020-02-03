using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;
    
    public Text levelText;
    int levelNumber;

    public TimerManager timerManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = this;
        timerManager = GetComponent<TimerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeLevel(int level, double target) {
        levelText.text = "Level " + level;
        levelNumber = level;
        
        timerManager.lifeTime = 60;
        Insta.insta.moreDestruction();
    }

    public int getLevel() {
        return levelNumber;
    }

}
