using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
	public float maxHealth;
	public float speed;
	public bool destroyWhenOutOfScreen = true;

	private float currentHealth;

	// Use this for initialization
	void Start () 
	{
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 direction = transform.rotation * Vector3.up;
		transform.position += direction * speed * Time.deltaTime;
	}

	public void HitByProjectile(StandardProjectile proj)
	{
		currentHealth -= proj.damage;

		if (currentHealth <= 0)
		{
			GameObject.Destroy(gameObject);
		}
	}

	public void CollisionWith(PlayerGameplayController player)
	{
		GameObject.Destroy(gameObject);
	}

	void OnBecameInvisible()
	{
		if (destroyWhenOutOfScreen)
		{
			GameObject.Destroy(gameObject);
		}
	}
}
