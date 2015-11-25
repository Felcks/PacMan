using UnityEngine;
using System.Collections;

public enum GHOSTBEHAVIOUR { CHASE, SCATTER , FRIGHTENED, FSCATTER};

public class Ghost : MonoBehaviour 
{
	protected GHOSTBEHAVIOUR ghostBehaviour;
	protected GameObject scatterTile;
}
