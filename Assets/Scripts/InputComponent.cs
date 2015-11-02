using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;



public class InputComponent : MonoBehaviour
{
	private SMF.TouchHandler touchHandler;

	public float MaxRotationSpeed = 100.0f;

	public float VelcocityChangeSpeed = 10.0f;
	public float MaxVelocity = 50.0f;
	public float MinVelocity = 0.0f;

	public float MaxPositionDelta = 25.0f;

	private float CurrentSpeed = 0.0f;

	// Use this for initialization
	void Start()
	{
		touchHandler = new SMF.TouchHandler();
	}



	// Update is called once per frame
	void Update()
	{
		Touch[] touches = touchHandler.GetTouches();

		if (touches.Length == 1)
		{
			UpdateSingleTouch(touches[0]);
		}
	}

	void UpdateSingleTouch(Touch touch)
	{
		float deltaX = touch.deltaPosition.x;
		float deltaY = touch.deltaPosition.y;

		if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
		{
			deltaX = Mathf.Clamp(deltaX, -MaxPositionDelta, MaxPositionDelta);
			float angle = MaxRotationSpeed * Time.deltaTime * -deltaX;
			transform.Rotate(new Vector3(0, 0, angle));
		}

		if (Mathf.Abs(deltaY) > Mathf.Abs(deltaX))
		{
			float accelerationFactor = Mathf.Clamp(deltaY, -MaxPositionDelta, MaxPositionDelta) / MaxPositionDelta;
			CurrentSpeed = Mathf.Clamp(CurrentSpeed + (VelcocityChangeSpeed * Time.deltaTime * accelerationFactor), MinVelocity, MaxVelocity);
		}

		Vector3 originalDir = new Vector3(0.0f, -1.0f, 0.0f);
		Vector3 newDir = transform.rotation * originalDir;

		Vector3 lineStart = transform.position;
		Debug.DrawLine(lineStart, lineStart + newDir * CurrentSpeed / MaxVelocity, Color.red);
	}

	void UpdateMultiTouch()
	{

	}
}
