using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
public class Insta : MonoBehaviour
{
    public static Insta insta;
    public GameObject p_gameOver;
    public GameObject prefab;
    public GameObject prefab2;

    public GameObject prefab3;
    public GameObject outfab;

    public GameObject dbSpot;

    public GameObject timeManager;

    public List<Vector3> list = new List<Vector3>();

    public List<Vector3> list2 = new List<Vector3>();

    public List<Sprite> sprites = new List<Sprite>();

    public MeshRenderer mymeshrender;

    public Material material1;

    public AudioSource mainSound;
    public GameObject player;

    public GameObject CanvasPlay;
    public GameObject CanvasVideo;

    public GameObject CanvasStart;

    public Button start;

    public GameObject Scripter;

    float initTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        insta = this;

        LoadGame();
        StartCoroutine("loadStart");

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().activePlayer)
        {
            StartCoroutine("GameOver");
        }
    }

    void constructScene()
    {
        int count = 91;
        for (int y = -4; y < 6; y++)
        {
            for (int x = -4; x < 6; x++)
            {
                prefab.GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprite/Map/" + count.ToString(), typeof(Sprite)) as Sprite;
                outfab = Instantiate(prefab, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0), dbSpot.transform);
                count++;
            }
            count -= 20;
        }
        //RandomObstacles();
    }

    void DestroyScene()
    {
        int cubeCount = dbSpot.transform.childCount;
        int child = Random.Range(0, cubeCount);
        Vector3 cubePos = dbSpot.transform.GetChild(child).transform.position;

        if (!list.Exists(element => element == cubePos) && !list2.Exists(element => element == cubePos))
        {

            
            Sprite sprite = dbSpot.transform.GetChild(child).gameObject.GetComponent<SpriteRenderer>().sprite;
            Destroy(dbSpot.transform.GetChild(child).gameObject, 0f);

            name = sprite.name;/* 
            Debug.Log(name);
            Debug.Log(Resources.Load("Sprite/Map/destroy/" + name, typeof(Sprite)) as Sprite); */
            prefab2.GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprite/Map/destroy/" + name, typeof(Sprite)) as Sprite;
            
            outfab = Instantiate(prefab2, cubePos, Quaternion.Euler(0, 0, 0), dbSpot.transform);
            sprites.Add(sprite);
            list.Add(cubePos);
        }

        // moreDestruction();
    }

    void RandomObstacles()
    {
        int limit = 30;
        int count = 0;
        do
        {


            int x = Random.Range(-5, 5);
            int y = Random.Range(-5, 5);

            Vector3 Vector = new Vector3(x, y, 0);

            if (!list2.Exists(element => element == Vector))
            {
                outfab = Instantiate(prefab3, Vector, Quaternion.Euler(0, 0, 0), dbSpot.transform);
                list2.Add(Vector);
                count++;
            }


        } while (count < limit);
    }

    public void moreDestruction()
    {
        incrementDestruction(0.2f);
    }

    public void incrementDestruction(float millisecond)
    {
        if (initTime > 0)
        {
            initTime -= millisecond;
        }
    }

    IEnumerator InitTime()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(initTime);
            if(PlayerController.playerController.activePlayer){  
                DestroyScene();
            }
        }
    }

    IEnumerator GameOver()
    {
        TimerManager timer = timeManager.GetComponent<TimerManager>();
        if (list.Count > 36 || timer.lifeTime == 0)
        {
            Scripter.SetActive(false);
            CanvasStart.SetActive(false);
            GameObject videoStartObject = CanvasVideo.transform.GetChild(1).gameObject;
            videoStartObject.SetActive(false);
            timer.countDown.text = "0:00";
            //
            mainSound.Stop();
            PlayerController controller = player.GetComponent<PlayerController>();
            controller.activePlayer = false;

            // p_gameOver.GetComponent<RawImage>().color = new Color(0, 0, 0, 0);
            p_gameOver.SetActive(true);


            /*for (float i = 0; i < 1.1; i += 0.1f)
            {
              
                p_gameOver.GetComponent<RawImage>().color = new Color(0, 0, 0, i);
            }*/
            yield return new WaitForSeconds(0.1f);
            StopAllCoroutines();
        }
    }

    void LoadGame()
    {
        Scripter.SetActive(false);
        p_gameOver.SetActive(false);
        CanvasPlay.SetActive(false);
        CanvasStart.SetActive(false);
        player.SetActive(false);
        player.GetComponent<PlayerController>().activePlayer = false;
        GameObject videoStartObject = CanvasVideo.transform.GetChild(1).gameObject;
        videoStartObject.SetActive(false);
        //mainSound.Stop();
        GameObject videoInitObject = CanvasVideo.transform.GetChild(0).gameObject;
        VideoPlayer videoInit = videoInitObject.GetComponent<VideoPlayer>();
        videoInit.Play();
    }

    IEnumerator loadStart()
    {

        GameObject videoInitObject = CanvasVideo.transform.GetChild(0).gameObject;
        VideoPlayer videoInit = videoInitObject.GetComponent<VideoPlayer>();

        while (true)
        {
            yield return new WaitForSeconds(1);
            if (!videoInit.isPlaying)
            {
                GameObject videoStartObject = CanvasVideo.transform.GetChild(1).gameObject;
                videoStartObject.SetActive(true);
                videoInitObject.SetActive(false);
                VideoPlayer videoStart = videoStartObject.GetComponent<VideoPlayer>();
            videoStart.Play();
                PauseGame();
                break;
            }
        }

    }

    public void PauseGame()
    {
        CanvasStart.SetActive(true);

        
        
        StopCoroutine("LoadStart");
    }
    public void initGame()
    {
        GameObject videoStartObject = CanvasVideo.transform.GetChild(1).gameObject;
        videoStartObject.SetActive(false);
        CanvasStart.SetActive(false);
        CanvasPlay.SetActive(true);
        player.SetActive(true);
        player.GetComponent<PlayerController>().activePlayer = true;
        StartCoroutine("InitTime");
        StartCoroutine("GameOver");
        constructScene();
        Scripter.SetActive(true);
        TimerManager.timepo.initate();
    }

    public void ExitGame(){
        Application.Quit();
    }

}
