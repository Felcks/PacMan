using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public Character character;

	void Start()
	{
		character = new Character (this.gameObject);

	}

	void Update()
	{

		this.gameObject.name = "Pacman_" + character.GetPosName ();
	}

}
