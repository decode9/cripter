using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public int lifeTime = 0;
    public Text countDown;
    public static TimerManager timepo;

    bool stopTime = false;

    // Start is called before the first frame update
    void Start()
    {
        timepo = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopTime) countDown.text = lifeTime == 60 ? "1:00" : ("0:" + lifeTime);
    }

    public void initate() {
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
    }

    IEnumerator LoseTime() {
        while(true) {
            yield return new WaitForSeconds(1);
            bool activePlayer = PlayerController.playerController.activePlayer;
            if(activePlayer) lifeTime--;

            if(!activePlayer) {
                int currentTime = lifeTime;
                lifeTime = currentTime;
                break;
            } 
        }

        StopAllCoroutines();
    }
   
}
