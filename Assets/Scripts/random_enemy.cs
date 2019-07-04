using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using static enemy_movement;

public class random_enemy : MonoBehaviour {
	public float create_interval = 1f;
	//	两次刷怪之间的时间间隔
	public float distance_to_player = 3f;
	//  为了不刷在主角附近，保持杂鱼生成位置距离主角在一倍该变量欧几里得距离和两倍曼哈顿距离
	public int enemies_per_creation = 3;
	//	每次刷几只怪
	private float next_creation_time = 1f;
	//	隔这段时间后生成下一个杂鱼
	private Vector2 pos;
	//	下一个杂鱼的出现位置
	private GameObject player;
	//	方便调用玩家的位置
	private string enemy = "Prefab_KR/zako_test";
	//	杂鱼预置体文件位置
	private GameObject tmp;
	//	指向新生成的杂鱼

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	private Vector2 random_position()
	{	//  生成下一个杂鱼的出现位置
		Vector2 OO = player.transform.position;	//	以玩家位置为起点
		// int sign = Random.Range(0,2)==1? 1 : -1;	//	决定了生成的坐标比玩家的大还是小
		//	Range好像是UnityEngine的函数，返回[0,2)的整数
		// System.Random rd = new System.Random();
		// pos.y = OO.y + sign*(distance_to_player + 
		// 	(float)rd.NextDouble()* distance_to_player);
		do
		{	//	循环到适当位置为止
			pos.x = OO.x + (float)(Random.Range(0,2001)-1000)/ 1000f* distance_to_player;
			pos.y = OO.y + (float)(Random.Range(0,2001)-1000)/ 1000f* distance_to_player;
		}while(Vector2.Distance(pos, OO) < distance_to_player);
		return pos;
	}
	
	// Update is called once per frame
	void Update ()
	{
		next_creation_time -= Time.deltaTime;	//	倒计时
		System.Random rd = new System.Random();
		if(next_creation_time <= 0f)
		{
			next_creation_time = create_interval + (float)rd.NextDouble()* create_interval;
			for(int i = 0; i < enemies_per_creation; ++i)
			{
				GameObject new_enemy = (GameObject)Resources.Load(enemy);
				//	上述方法似乎必须在Resources文件夹的相对路径使用
				// GameObject new_enemy = AssetDatabase.LoadAssetAtPath(enemy);
				//	上述方法似乎必须在Editor模式下使用
				tmp = Instantiate(new_enemy);	//	实例化
				// getComponent<RigidBody2D>().position;
				tmp.transform.position = random_position();
			}
		}
	}
}
