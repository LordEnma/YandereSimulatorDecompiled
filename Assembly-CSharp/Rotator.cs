using UnityEngine;

public class Rotator : MonoBehaviour
{
	public float speed = 15f;

	private void Update()
	{
		base.transform.Rotate(0f, speed * Time.deltaTime, 0f);
	}
}
