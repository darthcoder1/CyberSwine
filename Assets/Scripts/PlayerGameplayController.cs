using UnityEngine;
using System.Collections;

public class PlayerGameplayController : MonoBehaviour {

	public bool isShooting;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.LogWarning("HIT: " + other.name);

		if (other.gameObject.tag == "Enemy")
		{
			EnemyController ctrl = other.gameObject.GetComponent<EnemyController>();
			ctrl.CollisionWith(this);
		}
	}
}
