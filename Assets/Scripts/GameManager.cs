using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	public List<GameObject> tiles;
	public GameObject player;
	public GameObject blinky;
	public GameObject inky;
	public GameObject pinky;
	public GameObject clyde;
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
			GameObject p = (GameObject)Instantiate(this.player,CreateTiles.allGrounds[15][13].transform.position,Quaternion.identity);
			this.playerController = p.GetComponent<PlayerController>();
			this.playerController.objetiveIndex = this.tiles.Count/2 + 10;
			this.playerController.gameManager = this;
			this.playerController.score = this.GetComponent<ScoreManager>();

			GameObject b = (GameObject)Instantiate(this.blinky,CreateTiles.allGrounds[21][13].transform.position,Quaternion.identity);
			GameObject i = (GameObject)Instantiate(this.inky,CreateTiles.allGrounds[21][15].transform.position,Quaternion.identity);
			GameObject pi = (GameObject)Instantiate(this.pinky,CreateTiles.allGrounds[21][16].transform.position,Quaternion.identity);
			GameObject c = (GameObject)Instantiate(this.clyde,CreateTiles.allGrounds[21][17].transform.position,Quaternion.identity);
			b.gameObject.name = "Blinky_" + 21 + "" + 13;
			i.gameObject.name = "Inky_" + 21+ "" + 15;
			pi.gameObject.name = "Pinky_" + 21 + "" + 16; 
			c.gameObject.name = "Clyde_" + 21 + "" + 17;
		}
	}
}


