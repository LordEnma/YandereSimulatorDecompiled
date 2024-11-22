using UnityEngine;

public class DebugMenuTree : MonoBehaviour
{
	public bool DebugOn;

	public float CurentTimeSpeed;

	private void Start()
	{
		CurentTimeSpeed = 1f;
	}

	private void Update()
	{
		if (DebugOn)
		{
			if (Input.GetKeyDown("="))
			{
				CurentTimeSpeed += 1f;
			}
			else if (Input.GetKeyDown("-"))
			{
				CurentTimeSpeed -= 1f;
			}
			else if (Input.GetKeyDown("backspace"))
			{
				CurentTimeSpeed = 1f;
			}
			if (CurentTimeSpeed < 0f)
			{
				CurentTimeSpeed = 0f;
			}
			Time.timeScale = CurentTimeSpeed;
			if (Input.GetKeyDown("g"))
			{
				GetComponent<CamShotHandler>().ChangeCamera();
			}
		}
	}
}
