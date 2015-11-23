using UnityEngine;
using System.Collections;

public class FreeEnemySpawner : MonoBehaviour 
{
	// Enemy count to spawn per minute (y=Enemies per minute, x=minutes played)
	public AnimationCurve enemyCountOverTime;
	// Enemy count to spawn per minute (y=Desired Squadron size, x=minutes played)
	public AnimationCurve enemySquadronSize;

	public float enemyFormationOffset = 1.0f;
	public float zPos = -0.25f;

	public float spawnInterval = 15.0f;
	private float timeSinceLastSpawn;
	private float timeSinceStart;
	private Quaternion defaultSpawnRotation;

	public GameObject EnemyTemplate_BasicEnemy;

	// Use this for initialization
	void Start () 
	{
		timeSinceLastSpawn = 0.0f;
		timeSinceStart = 0.0f;
		defaultSpawnRotation = Quaternion.EulerRotation(0, 0, Mathf.Deg2Rad * 180.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeSinceLastSpawn += Time.deltaTime;
		timeSinceStart += Time.deltaTime;

		if (timeSinceLastSpawn >= spawnInterval)
		{
			timeSinceLastSpawn = 0.0f;
			SpawnEnemies();
		}
	}

	private void SpawnEnemies()
	{
		float enemiesPerMinute = enemyCountOverTime.Evaluate(timeSinceStart / 60.0f);
		int enemySquadSize = Mathf.FloorToInt(enemySquadronSize.Evaluate(timeSinceStart / 60.0f));

		int enemiesToSpawn = Mathf.CeilToInt(enemiesPerMinute / (60.0f / spawnInterval));
		
		while (enemiesToSpawn > 0)
		{
			if (enemiesToSpawn >= enemySquadSize)
			{
				int spawnedEnemies = SpawnEnemySquad(enemySquadSize);
				enemiesToSpawn -= spawnedEnemies;
			}
			else
			{
				SpawnSingleEnemy(EnemyTemplate_BasicEnemy, CalculateSquadPosition(1), defaultSpawnRotation);
				--enemiesToSpawn;
			}
		}
	}

	private Vector3 GenerateSquadFormationVector()
	{
		float randRotation = Random.value * 320.0f;
		Vector3 direction = Quaternion.EulerAngles(0, 0, randRotation) * Vector3.up;
		direction.z = 0;
		return direction;
	}


	private int SpawnEnemySquad(int squadSize)
	{
		Debug.Assert(squadSize > 1);
		Debug.LogWarning("SpawnEnemySquad");

		Vector3 squadDirection = GenerateSquadFormationVector();
		Vector3 startPoint = CalculateSquadPosition(squadSize) - squadDirection * (squadSize - 1);

		for (int i=0; i < squadSize; ++i)
		{
			SpawnSingleEnemy(EnemyTemplate_BasicEnemy, startPoint, defaultSpawnRotation);
			startPoint += squadDirection * enemyFormationOffset;
		}
		return squadSize;
	}

	private GameObject SpawnSingleEnemy(Object enemyTemplate, Vector3 enemyPosition, Quaternion enemyRotation)
	{
		GameObject obj = GameObject.Instantiate(enemyTemplate, enemyPosition, enemyRotation) as GameObject;

		return obj;
	}

	private Vector3 CalculateSquadPosition(int squadSize)
	{
		float xPos = Mathf.Clamp(Random.value, 0.2f, 0.8f) * Screen.width;
		float yPos = Screen.height * 1.5f;
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(xPos, yPos));
		worldPos.z = zPos;
		return worldPos;
	}
}
