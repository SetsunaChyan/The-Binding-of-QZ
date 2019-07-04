using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	struct KeyOrder : IComparable<KeyOrder>
	{
		public int dir;
		public int pos;
		public int CompareTo(KeyOrder a)
		{
			if(this.pos>a.pos) return -1;
			if(this.pos<a.pos) return 1;
			return 0;
		}
	};

	//direction
	private const int UP=0;
	private const int LEFT=1;
	private const int DOWN=2;
	private const int RIGHT=3; 
	private KeyOrder[] keyOrder=new KeyOrder[4]; //存四个方向键按下的顺序
	private KeyOrder[] keyOrdertmp=new KeyOrder[4];

	private int currentHP;
	private Rigidbody2D rigidbody2d;
	private bool isInvincible;
	private float invincibleTimer;
	private int direction;
	
	public float Speed;
	public int MaxHP;
	public int MinHP;

	public int CurrentHP
	{
		get{ return currentHP;}
		set{ currentHP=value;}
	}

	void Start() 
	{
		rigidbody2d=GetComponent<Rigidbody2D>();
        currentHP=MaxHP;
        isInvincible=false;
		for(int i=0;i<4;i++)
		{
			keyOrder[i].dir=i;
			keyOrder[i].pos=0;
		}
	}
	
	void Update()
	{
		float horizontal=Input.GetAxis("Horizontal");
        float vertical=Input.GetAxis("Vertical");
		int maxkeyOrder=0;
		for(int i=0;i<4;i++)
			maxkeyOrder=Mathf.Max(maxkeyOrder,keyOrder[i].pos);
		if(Input.GetKeyDown(KeyCode.LeftArrow)) keyOrder[LEFT].pos=++maxkeyOrder;
		else if(Input.GetKeyDown(KeyCode.RightArrow)) keyOrder[RIGHT].pos=++maxkeyOrder;
		else if(Input.GetKeyDown(KeyCode.UpArrow)) keyOrder[UP].pos=++maxkeyOrder;
		else if(Input.GetKeyDown(KeyCode.DownArrow)) keyOrder[DOWN].pos=++maxkeyOrder;
		if(Input.GetKeyUp(KeyCode.LeftArrow)) keyOrder[LEFT].pos=0;
		else if(Input.GetKeyUp(KeyCode.RightArrow)) keyOrder[RIGHT].pos=0;
		else if(Input.GetKeyUp(KeyCode.UpArrow)) keyOrder[UP].pos=0;
		else if(Input.GetKeyUp(KeyCode.DownArrow)) keyOrder[DOWN].pos=0;
		for(int i=0;i<4;i++)
			keyOrdertmp[i]=keyOrder[i];
		Array.Sort(keyOrdertmp);
		if(keyOrdertmp[0].pos!=0) direction=keyOrdertmp[0].dir;

		//更新位置
        Vector2 position=rigidbody2d.position;
        position.x+=Speed*horizontal*Time.deltaTime;
        position.y+=Speed*vertical*Time.deltaTime;
        rigidbody2d.MovePosition(position);

		//更新朝向
		Vector3 rotation=transform.localEulerAngles;
		if(direction==UP) rotation.z=0;
		else if(direction==DOWN) rotation.z=180;
		else if(direction==LEFT) rotation.z=90;
		else if(direction==RIGHT) rotation.z=270;
		transform.localEulerAngles=rotation;

		//更新无敌时间
        if(isInvincible)
        {
            invincibleTimer-=Time.deltaTime;
            if(invincibleTimer<0) isInvincible=false;
        }
	}
}
