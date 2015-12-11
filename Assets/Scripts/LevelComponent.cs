using UnityEngine;
using System.Collections;

public class LevelComponent : MonoBehaviour 
{
	private static LevelComponent s_Instance;

	public static LevelComponent Instance
	{
		get
		{
			return s_Instance;
		}
	}

	public float globalScrollSpeed = 4;
	public float spawnZPosition = -0.25f;

	// Use this for initialization
	void Start () 
	{
		s_Instance = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public Vector3 GenerateRandomSpawnPosition(float safeZone)
	{
		float xPos = Mathf.Clamp(Random.value, safeZone, 1.0f - safeZone) * Screen.width;
		float yPos = Screen.height * 1.5f;
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(xPos, yPos));
		worldPos.z = spawnZPosition;
		return worldPos;
	}
}
