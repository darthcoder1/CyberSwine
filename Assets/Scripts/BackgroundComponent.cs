using UnityEngine;
using System.Collections;

public class BackgroundComponent : SMF.SpriteAnimationComponent
{
	public bool useGlobalSpeed = true;

	// Use this for initialization
	public new void Start () 
	{
		base.Start();
	}
	
	// Update is called once per frame
	public new void Update() 
	{
		if (useGlobalSpeed)
		{
			panSpeed = new Vector2(0.0f, LevelComponent.Instance.globalScrollSpeed * -0.1f);
		}

		base.Update();
	}
}
