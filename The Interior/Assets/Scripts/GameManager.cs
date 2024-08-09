using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool access2A = false;
    public bool access2B = false;
    public bool access3 = false;

    public bool squareDone = false;
    public bool circleDone = false;
    public bool triDone = false;

    private bool runChance = true;
    public bool lightsEvent = false;
    public GameObject lightO;
    
    public GameObject computerScreen;
    public GameObject computerScreen2;
    public GameObject gameOver;

    private bool gameOverYet = false;
    public AudioSource morseCode;

    public void Start()
    {
        instance = this;
    }

    public void BeginGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void closeScreen()
    {
        MouseLook.instance.active = true;
        Cursor.lockState = CursorLockMode.Locked;
        computerScreen.SetActive(false);
    }
    public void closeScreen2()
    {
        MouseLook.instance.active = true;
        Cursor.lockState = CursorLockMode.Locked;
        computerScreen2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(runChance)
        {
            if(Random.Range(0f, 1f) < 0f)
            {
                runChance = false;
                lightsEvent = true;
                lightO.SetActive(false);
                AudioManager.instance.LightsOff();
            }
            else
            {
                runChance = false;
                StartCoroutine(ChanceCooldown());
            }
        }
    }

    IEnumerator ChanceCooldown()
    {
        yield return new WaitForSeconds(30f);
    }

    public void Check3Done()
    {
        if(squareDone && circleDone && triDone)
        {
            access3 = true;
        }
        if(access3)
        {
            RoomSwitch.instance.ToRoom3();
            while (gameOverYet == false)
            {
                morseCode.Play();
            }
        }
    }

    public void EndGame()
    {
        StartCoroutine(EndCooldown());
    }

    private IEnumerator EndCooldown()
    {
        gameOver.SetActive(true);
        gameOverYet = true;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
