using UnityEngine;
using System.Collections;

public class PlayerGameplayController : MonoBehaviour {

	public bool isShooting;

	private SMF.RubberBandController inputComp;

	// Use this for initialization
	void Start () 
	{
		inputComp = GetComponent<SMF.RubberBandController>();
		Debug.Assert(inputComp);
	}
	
	// Update is called once per frame
	void Update () 
	{
		isShooting = inputComp.numActiveTouches > 0;
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
