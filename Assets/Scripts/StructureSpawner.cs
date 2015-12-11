using UnityEngine;
using System.Collections;

public class StructureSpawner : MonoBehaviour {

	public GameObject[] structureTemplates;

	public float spawnInterval = 15.0f;
	private float timeSinceLastSpawn;
	private float timeSinceStart;
	
	// Use this for initialization
	void Start ()
	{
		timeSinceLastSpawn = 0.0f;
		timeSinceStart = 0.0f;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeSinceLastSpawn += Time.deltaTime;
		timeSinceStart += Time.deltaTime;

		if (timeSinceLastSpawn >= spawnInterval)
		{
			timeSinceLastSpawn = 0.0f;
			Spawn();
		}
	}

	void Spawn()
	{
		if (structureTemplates != null && structureTemplates.Length > 0)
		{
			GameObject.Instantiate(structureTemplates[Random.RandomRange(0, structureTemplates.Length)], LevelComponent.Instance.GenerateRandomSpawnPosition(), Quaternion.identity);
		}
	}
}
