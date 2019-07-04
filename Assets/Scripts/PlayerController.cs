using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	//direction
	private const int UP=0;
	private const int LEFT=1;
	private const int DOWN=2;
	private const int RIGHT=3; 

	private int currentHP;
	private Rigidbody2D rigidbody2d;
	private bool isInvincible;
	private float invincibleTimer;
	private int direction; //0:up 1:left 2:down 3:right

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
	}
	
	void Update()
	{
		float horizontal=Input.GetAxis("Horizontal");
        float vertical=Input.GetAxis("Vertical");

		//更新位置
        Vector2 position=rigidbody2d.position;
        position.x+=Speed*horizontal*Time.deltaTime;
        position.y+=Speed*vertical*Time.deltaTime;

        rigidbody2d.MovePosition(position);

		//更新朝向
		Vector3 rotation=transform.localEulerAngles;
		if(direction==0) rotation.z=0;
		else if(direction==1) rotation.z=90;
		else if(horizontal>0&&vertical<0) rotation.z=180;
		if(horizontal<0&&vertical<0) rotation.z=270;
		transform.localEulerAngles=rotation;

		//更新无敌时间
        if(isInvincible)
        {
            invincibleTimer-=Time.deltaTime;
            if(invincibleTimer<0) isInvincible=false;
        }
	}
}
