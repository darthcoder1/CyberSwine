using UnityEngine;
using System.Collections;

public class LevelComponent : MonoBehaviour 
{
	private static LevelComponent s_Instance;

	public static LevelComponent Instance
	{
		get
		{
			return s_Instance;
		}
	}

	public float globalScrollSpeed = 4;

	// Use this for initialization
	void Start () 
	{
		s_Instance = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
