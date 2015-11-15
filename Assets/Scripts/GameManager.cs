using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	public List<GameObject> tiles;
	public GameObject player;
	public GameObject blinky;
	public bool started;
	public PlayerController playerController;
	public GameObject[][] ground;
	private float[][]blocos;

	void Start()
	{
		this.ground = new GameObject[28][];
		for(int i=0; i<this.ground.Length;i++)
		{
			this.ground[i] = new GameObject[36];
			for(int j=0; j<this.ground[i].Length; j++)
				this.ground[i][j] = GameObject.Find("GameManager"); //Preenche para nao dar erro!
		}
	}

	void Update()
	{
		StartGame ();
	}

	void StartGame()
	{
		if(this.tiles.Count == 28*36 && !this.started) //Se todos os Tiles foram instanciados
		{
			this.started = true;
			GameObject p = (GameObject)Instantiate(this.player,this.tiles[this.tiles.Count/2 + 25].transform.position,Quaternion.identity);
			this.playerController = p.GetComponent<PlayerController>();
			this.playerController.objetiveIndex = this.tiles.Count/2 + 10;
			this.playerController.gameManager = this;
			this.playerController.score = this.GetComponent<ScoreManager>();

			GameObject b = (GameObject)Instantiate(this.blinky,CreateTiles.allGrounds[18][27].transform.position,Quaternion.identity);
			b.gameObject.name = "Blinky_" + 18 + "" + 27;
		}
	}
}


