using UnityEngine;
using System.Collections;

public class PlayerGameplayController : MonoBehaviour {

	public bool isShooting;

	private SMF.RubberBandController inputComp;
	private Animator animComp;

	// Use this for initialization
	void Start () 
	{
		inputComp = GetComponent<SMF.RubberBandController>();
		animComp = GetComponent<Animator>();

		Debug.Assert(inputComp);
		Debug.Assert(animComp);
	}
	
	// Update is called once per frame
	void Update () 
	{
		isShooting = inputComp.numActiveTouches > 0;

		animComp.SetFloat("X_Input", inputComp.currentVelocity.x);
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
