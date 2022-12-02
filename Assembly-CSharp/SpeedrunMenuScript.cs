using UnityEngine;

public class SpeedrunMenuScript : MonoBehaviour
{
	public Animation YandereAnim;

	private void Start()
	{
		YandereAnim["f02_nierRun_00"].speed = 1.5f;
	}

	private void Update()
	{
	}
}
