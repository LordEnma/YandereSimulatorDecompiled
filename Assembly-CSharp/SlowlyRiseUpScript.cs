using UnityEngine;

public class SlowlyRiseUpScript : MonoBehaviour
{
	public Transform Target;

	public float Speed;

	public bool Begin;

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			Begin = true;
		}
		if (Begin)
		{
			Speed += Time.deltaTime;
			base.transform.position = Vector3.Lerp(base.transform.position, Target.position, Time.deltaTime * Speed);
		}
	}
}
