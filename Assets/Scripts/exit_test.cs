using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exit_test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Button>().onClick.AddListener(exit);
	}

    public void exit()
    {
        Debug.Log("退出了游戏！！！！！");
        Application.Quit();
    }
}
