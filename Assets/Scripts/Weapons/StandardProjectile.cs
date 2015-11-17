using UnityEngine;
using System.Collections;

public class StandardProjectile : MonoBehaviour 
{
	public float speed;
	public float damage;
	public Vector2 direction = new Vector2(0.0f, -1.0f);

	private Collider2D colliderComp;
	private SpriteRenderer spriteComp;

	// Use this for initialization
	void Start () 
	{
		colliderComp = GetComponent<Collider2D>();
		spriteComp = GetComponent<SpriteRenderer>();

		Debug.Assert(colliderComp);
		Debug.Assert(spriteComp);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = transform.position + new Vector3(direction.x, direction.y, 0.0f) * speed * Time.deltaTime;
	}

	void OnBecameInvisible()
	{
		Debug.LogWarning("Invisible");
		GameObject.Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.LogWarning("HIT: " + other.name);
	}
}
