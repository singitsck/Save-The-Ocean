using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamingUI : MonoBehaviour
{
    public Text Money;
    public Text Target;
    public Text LevelTime;
    public Text Level;


    public int money;
    public int target;
    public float levelTime;
    public int level; //UI data
    public GameObject GameOver;
    public GameObject GameClear;
    // Start is called before the first frame update
    void Start()
    {
        Money.text = money.ToString();
        Target.text = target.ToString();
        LevelTime.text = levelTime.ToString();
        Level.text = level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
  
        LevelTime.text = (levelTime -= Time.deltaTime).ToString();//time-
        if (levelTime <= 0)
        {
            levelTime = 0;
            GameOver.SetActive(true);//show end
            Time.timeScale = 0;//stop game time
        }
        if(money >= target)
        {
            GameClear.SetActive(true);//show end
            Time.timeScale = 0;//stop game time
        }
    }

    public void OnMoney(int Value)
    {
        money = money + Value;
        Money.text = money.ToString();
    }
}
