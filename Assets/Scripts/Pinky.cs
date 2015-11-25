using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pinky : MonoBehaviour 
{
	public List<GameObject> openList;
	public List<GameObject> closedList;
	public List<GameObject> rightWay;
	public GameObject objetive;
	public GameObject fourTilesFoward;
	public GameObject player;
	public GameObject blinky;
	public PlayerController playerController;
	public GameObject nexTile;
	public Vector3 currentDirection;
	string posX;
	string posY;
	
	void Start()
	{
		openList = new List<GameObject> ();
		closedList = new List<GameObject> ();
		rightWay = new List<GameObject> ();
		
		this.posX = this.name.Substring (this.name.Length - 4, 2);
		this.posY = this.name.Substring (this.name.Length - 2, 2);
		
		
		this.player = GameObject.FindWithTag (Tags.player);
		this.playerController = this.player.GetComponent<PlayerController> ();
		this.SetFourTilesFoward ();
		
	}
	
	void SetFourTilesFoward()
	{
		string playerPosX = this.player.name.Substring (this.player.name.Length - 4, 2);
		string playerPosY = this.player.name.Substring (this.player.name.Length - 2, 2);
		
		int player_X = int.Parse (playerPosX);
		int player_Y = int.Parse (playerPosY);
		
		switch(this.playerController.getCurrentDirection())
		{
		case (int)DIRECTION.UP:
			player_X += 4;
			break;
		case (int)DIRECTION.DOWN:
			player_X += -4;
			break;
		case (int)DIRECTION.LEFT:
			player_Y += -4;
			break;
		case (int)DIRECTION.RIGHT:
			player_Y += 4;
			break;
		}
		
		string addZeroX =  (player_X <= 9) ? "0" : "";
		string addZeroY =  (player_Y <= 9) ? "0" : "";

		this.objetive = GameObject.Find ("Ground_" + addZeroX + "" + player_X + "" + addZeroY + "" + player_Y);
		this.GetAroundTiles ();
	
	}
	

	void Update()
	{		
		
		this.SetFourTilesFoward ();

		
		if (this.nexTile == null)
			return;
		
		
		if(Vector3.Distance(this.transform.position, this.nexTile.transform.position) < 0.01f)
		{
			this.name = "Pinky_" + this.nexTile.name.Substring (this.nexTile.name.Length - 4, 2) + "" +  this.nexTile.name.Substring (this.nexTile.name.Length - 2, 2);
			
			this.GetAroundTiles();
		}
		
		this.transform.position = Vector3.MoveTowards (this.transform.position, nexTile.transform.position, Time.deltaTime);
	}
	
	public void GetAroundTiles()
	{
		this.posX = this.name.Substring (this.name.Length - 4, 2);
		this.posY = this.name.Substring (this.name.Length - 2, 2);
		
		
		int index_X = int.Parse (posX);
		int index_Y = int.Parse (posY);
		
		string addZeroX =  (index_X <= 9) ? "0" : "";
		string addZeroY =  (index_Y <= 9) ? "0" : "";
		
		GameObject upTile =  GameObject.Find ("Ground_"  + ((index_X + 1 <= 9) ? "0" : "") + (index_X + 1) + addZeroY + index_Y );
		GameObject downTile =  GameObject.Find ("Ground_"  + ((index_X - 1 <= 9) ? "0" : "") + ((index_X) - 1) + "" + addZeroY + index_Y );
		GameObject rightTile =  GameObject.Find ("Ground_"  + addZeroX + index_X + ((index_Y + 1 <= 9) ? "0" : "") + (index_Y + 1));
		GameObject leftTile =  GameObject.Find ("Ground_"  + addZeroX + index_X + ((index_Y-1 <=9) ? "0" : "") + (index_Y - 1));
		
		if(index_Y == 27)
		{
			rightTile = GameObject.Find("Ground_1800"); 
		}
		if(upTile.tag.Equals(Tags.ground))
		{
			openList.Add(upTile);
		}
		if(downTile.tag.Equals(Tags.ground))
		{
			openList.Add(downTile);
		}
		if(rightTile.tag.Equals(Tags.ground))
		{
			openList.Add(rightTile);
		}
		if(leftTile.tag.Equals(Tags.ground))
		{
			openList.Add(leftTile);
		}
		
		this.GoToBetterTile ();
	}
	
	private void GoToBetterTile()
	{
		GameObject betterTile = openList[0];
		float betterDistance = 999;
		
		for(int i = 0; i<this.openList.Count; i++)
		{
			float distance = Vector3.Distance(openList[i].transform.position, objetive.transform.position);
			if(distance < betterDistance)
			{
				betterDistance = distance;
				betterTile = this.openList[i];
			}
		}
		
		this.openList = new List<GameObject> ();
		this.nexTile = betterTile;
	}
}
