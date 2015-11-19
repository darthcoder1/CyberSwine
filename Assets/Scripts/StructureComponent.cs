using UnityEngine;
using System.Collections;

public class StructureComponent : MonoBehaviour 
{
	public bool useGlobalSpeed = true;
	public float speed;

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
