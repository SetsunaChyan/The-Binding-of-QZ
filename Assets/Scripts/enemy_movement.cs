#define DEBUG
#undef DEBUG
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
public class enemy_movement : MonoBehaviour 
{

	public float move_per_frame = 0.04f;
	//  this每帧移动量
	
	private Rigidbody2D rigidbody2d;
	//  this的刚体

	public float distance(Vector2 a, Vector2 b)
	{	//  求坐标a到坐标b的距离，似乎可以用Vector2.Distance代替……
		float dx = b.x - a.x;
		float dy = b.y - a.y;
		return (float)System.Math.Sqrt(dx*dx + dy*dy);
	}
	// Use this for initialization
	void Start () 
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 pos = rigidbody2d.position;	//  this在当前帧的目标移动位置
		Vector2 destination;	//  当前帧的目标位置

		#if DEBUG
			// Camera camera = GetComponent<Camera>();	//  这行代码好像不OK 	
			GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
			destination.x = camera.transform.position.x;
			destination.y = camera.transform.position.y;
			//  试试向摄像机范围正中跑
		#else
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			destination = player.transform.position;
		#endif

		Vector2 velocity;	//  当前帧的位移偏移量
		velocity = destination - pos;
		// velocity /= distance(destination, pos);
		velocity /= Vector2.Distance(destination, pos);
		velocity *= move_per_frame;
		pos += velocity;
		rigidbody2d.MovePosition(pos);
	}
}
