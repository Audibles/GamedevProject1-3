using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class UIManager : MonoBehaviour {

    //Singleton UIManager.
    public static UIManager uiManager;

    GameObject LoadingBackground;
    Image LoadingLives;
    GameObject Score;
    List<Image> ScoreDigits = new List<Image>();
    GameObject Coins;
    List<Image> CoinsDigits = new List<Image>();
    GameObject Timer;
    List<Image> TimerDigits = new List<Image>();
    List<Image> LoadingLivesDigit = new List<Image>();
    string pathToSprites = "NES - Super Mario Bros - Font(Transparent)";
    public Object assetTest;
    Sprite[] numberSprites;
    float loadTime = 1.5f;
    int playerLives = 3;
    int playerScore = 0;
    int playerTime = 330;
    int playerCoins = 0;

    // Use this for initialization
    void Start()
    {
        if (uiManager == null)
        {
            uiManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
        LoadingBackground = GameObject.Find("Loading_Background");
        LoadingLives = GameObject.Find("Loading_Lives").GetComponent<Image>();
        LoadingLivesDigit.Add(LoadingLives);
        numberSprites = Resources.LoadAll(pathToSprites).OfType<Sprite>().Take(10).ToArray();
        Score = GameObject.Find("Score");
        foreach (Transform child in Score.transform)
        {
            ScoreDigits.Add(child.GetComponent<Image>());
        }
        Coins = GameObject.Find("Coins");
        foreach (Transform child in Coins.transform)
        {
            CoinsDigits.Add(child.GetComponent<Image>());
        }
        Timer = GameObject.Find("Timer");
        foreach (Transform child in Timer.transform)
        {
            TimerDigits.Add(child.GetComponent<Image>());
        }
        SetDigits(ScoreDigits, playerScore);
        SetDigits(CoinsDigits, playerCoins);
        SetDigits(TimerDigits, playerTime);
        SetDigits(LoadingLivesDigit, playerLives);
        LoadingBackground.SetActive(false);
    }

    void SetDigits(List<Image> digits, int result)
    {
        int placeCounter = 0;
        while (result / (int) Mathf.Pow(10, placeCounter) > 0) {
            placeCounter += 1;
        }
        placeCounter -= 1;
        IEnumerator<Image> digitsEnum = digits.GetEnumerator();
        digitsEnum.MoveNext();
        while (placeCounter >= 0) {
            int digit = result / (int) (Mathf.Pow(10, placeCounter));
            result = result % (int)(Mathf.Pow(10, placeCounter));
            if (digit >= 10) {
                int maxNum = 0;
                while (placeCounter >= 0) {
                    maxNum += (9 * (int) Mathf.Pow(10, placeCounter));
                    placeCounter -= 1;
                }
                SetDigits(digits, maxNum);
                return;
            }
            digitsEnum.Current.sprite = numberSprites[digit];
            digitsEnum.MoveNext();
            placeCounter -= 1;
        }
    }

    /* Called every time the Main Scene is loaded.
     * Do not use SceneManager.LoadScene(). */
    public void LoadScene()
    {
        playerTime = 330;
        SetDigits(TimerDigits, playerTime);
        StopCoroutine("KeepTime");
        StartCoroutine("ShowLoadingScreen");
    }

    /* Would update the player's score. Functionality not 
     * yet added. */
    public void UpdateScore(int scoreToAdd) {
        playerScore += scoreToAdd;
        SetDigits(ScoreDigits, playerScore);
    }

    /* Use coroutine for spending time on Loading screen. */
    IEnumerator ShowLoadingScreen()
    {
        LoadingBackground.SetActive(true);
        yield return new WaitForSeconds(loadTime);
        LoadingBackground.SetActive(false);
        SceneManager.LoadScene("Main Scene");
        StartCoroutine("KeepTime");
        yield break;
    }

    IEnumerator KeepTime() {
        while (playerTime > 0)
        {
            yield return new WaitForSeconds(1);
            playerTime -= 1;
            SetDigits(TimerDigits, playerTime);
        }
        TakeLife();
        LoadScene();
        yield break;
    }

    /* Called each time an enemy takes a life from Mario.
     * If he still has lives left, it will just reload the 
     * main scene. If not, it will reload the Menu Scene
     * and reset the player's lives for another attempt. */
    public void TakeLife() {
        playerLives -= 1;
        SetDigits(LoadingLivesDigit, playerLives);
        if (playerLives == 0)
        {
			SceneManager.LoadScene("Main Scene");
			playerLives = 3;
        }
        else
        {
			LoadScene ();
        }
    }

    /* Would count the coins that the player has picked up.
     * Functionality not yet added. */
    public void AddCoin() {
        playerCoins += 1;
        SetDigits(CoinsDigits, playerCoins);
    }
}
