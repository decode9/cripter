using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverBlock : MonoBehaviour
{
    public static RecoverBlock recoverBlock;

    public GameObject Controller;
    public GameObject outfab;
    public GameObject model;

    public GameObject dbSpot;
    public Vector3 position;
    public AudioSource audioData;

    public double currentScore = 0.0005;
    public double incrementScore = 0.005;
    public int levelInit = 1;

    public ParticleSystem smoke;

    // Start is called before the first frame update
    void Start()
    {
        recoverBlock = this;
        position = transform.position;
        smoke.Play();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Player"){
            Insta db = Controller.gameObject.GetComponent<Insta>();
            int index = db.list.IndexOf(position);
            Sprite sprite = db.sprites[index];
            model.GetComponent<SpriteRenderer>().sprite = sprite;
            db.list.Remove(position);
            db.sprites.Remove(sprite);

            ScoreManager.scoreManager.raiseScore(currentScore);

            outfab = Instantiate(model, position, Quaternion.Euler(0,0,0), dbSpot.transform);
            audioData.Play(0);
            smoke.Stop();
            Destroy(gameObject);
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        assignGoals();
    }

    public void assignGoals() {
        double actualValue = ScoreManager.scoreManager.getTotalScore();
        double targetValue = incrementScore + incrementScore;

        if(actualValue >= targetValue) {
            LevelManager.levelManager.changeLevel(levelInit += 1, targetValue);
            incrementScore = targetValue;
        }
    }
}
