using UnityEngine;

public class VibrateScript : MonoBehaviour
{
	public Vector3 Origin;

	private void Start()
	{
		Origin = base.transform.localPosition;
	}

	private void Update()
	{
		base.transform.localPosition = new Vector3(Origin.x + Random.Range(-5f, 5f), Origin.y + Random.Range(-5f, 5f), base.transform.localPosition.z);
	}
}
