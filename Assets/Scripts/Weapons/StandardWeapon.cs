using UnityEngine;
using System.Collections;

public class StandardWeapon : MonoBehaviour 
{
	PlayerGameplayController playerCtrl;

	public GameObject projectilePrefab;
	
	public float refireRate;
	public int numShots;

	private float timeSinceLastShot;
	
	// Use this for initialization
	void Start () 
	{
		playerCtrl = GetComponent<PlayerGameplayController>();
		Debug.Assert(playerCtrl);

		timeSinceLastShot = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeSinceLastShot += Time.deltaTime;

		if (timeSinceLastShot >= refireRate && playerCtrl.isShooting)
		{
			timeSinceLastShot = 0.0f;

			for (int i = 0; i < numShots; ++i)
			{
				GameObject proj = Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
				StandardProjectile projInfo = proj.GetComponent<StandardProjectile>();
			}
		}
	}
}
