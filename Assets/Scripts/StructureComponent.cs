using UnityEngine;
using System.Collections;

public class StructureComponent : MonoBehaviour 
{
	public bool useGlobalSpeed = true;
	public float speed;

	// a simple structure is just a sprite, no additional setup. If true, the sprite can be varied randomly by the spawner
	public bool simpleStructure;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float currentSpeed = speed;
		if (useGlobalSpeed)
		{
			currentSpeed = LevelComponent.Instance.globalScrollSpeed;
		}

		transform.position += Vector3.down * currentSpeed * Time.deltaTime;
	}

	void OnBecameInvisible()
	{
		GameObject.Destroy(gameObject);
	}
}
