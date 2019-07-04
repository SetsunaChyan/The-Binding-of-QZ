using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//调用场景管理器
using UnityEngine.SceneManagement;

public class Start_Page_Scripts : MonoBehaviour {

    float botton_width = 100;
    float botton_height = 50;
    float label_width = 200;
    float label_height = 50;

    float bottonX;
    float bottonY;
    float labelX;
    float labelY;

    Rect botton_pos;
    Rect botton2_pos;
    Rect label_pos;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        //字体设置
        GUIStyle style = new GUIStyle();
        style.normal.textColor = new Color(1, 0, 0);
        style.fontSize = 50;
        //左边距离 顶部距离 宽度 高度
        bottonX = (Screen.width - botton_width) / 2;
        bottonY = (Screen.height - botton_height) / 2;
        labelX = bottonX - (label_width - botton_width);
        labelY = bottonY - 100;
        botton_pos = new Rect(bottonX, bottonY, botton_width, botton_height);
        //布尔返回值用于设置事件监听
        if (GUI.Button(botton_pos, "START"))
        {
            start_game();
        }
        label_pos = new Rect(labelX, labelY, label_width, label_height);
        GUI.Label(label_pos, "TEST GAME",style);
        botton2_pos = new Rect(bottonX, bottonY+botton_height+25, botton_width, botton_height);
        if(GUI.Button(botton2_pos, "EXIT"))
        {
            exit_game();
        }
    }

    void start_game()
    {
        Debug.Log("开始按钮被点击！！！");
        SceneManager.LoadScene("Main_Scene");
    }

    void exit_game()
    {
        Debug.Log("退出按钮被点击！！！");
        Application.Quit();
    }
}
