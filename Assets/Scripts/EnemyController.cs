using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
	public float maxHealth;

	private float currentHealth;

	// Use this for initialization
	void Start () 
	{
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void HitByProjectile(StandardProjectile proj)
	{
		currentHealth -= proj.damage;

		if (currentHealth <= 0)
		{
			GameObject.Destroy(gameObject);
		}
	}
}
