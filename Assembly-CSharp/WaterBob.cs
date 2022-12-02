using UnityEngine;

[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
	[SerializeField]
	private float height = 0.1f;

	[SerializeField]
	private float period = 1f;

	private Vector3 initialPosition;

	private float offset;

	private void Awake()
	{
		initialPosition = base.transform.position;
		offset = 1f - Random.value * 2f;
	}

	private void Update()
	{
		base.transform.position = initialPosition - Vector3.up * Mathf.Sin((Time.time + offset) * period) * height;
	}
}
