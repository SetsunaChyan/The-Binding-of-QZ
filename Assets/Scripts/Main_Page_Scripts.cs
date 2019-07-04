using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Page_Scripts : MonoBehaviour {

    public Canvas Canvas;
    public Button score_button,exit_button,hp_button;
    public Text information;

    int hp = 2;
    int score = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void hp_minus()
    {
        Debug.Log("HP");
        if (hp > 0)
        {
            hp--;
            information.text = "血量：" + hp.ToString() + "分数：" + score.ToString();
        }
        if(hp == 0)
        {
            SceneManager.LoadScene("Dead_Page");
        }
    }

    public void score_add()
    {
        Debug.Log("SCORE");
        score++;
        information.text = "血量：" + hp.ToString() + "分数：" + score.ToString();
    }

    public void exit()
    {
        Debug.Log("EXIT");
        Application.Quit();
    }
}
