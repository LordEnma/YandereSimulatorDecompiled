using UnityEngine;

public class WobbleScript : MonoBehaviour
{
	public Vector3 RotateSpeed = new Vector3(10f, 10f, 10f);

	public Vector3 WobbleAmount = new Vector3(0.1f, 0.1f, 0.1f);

	public Vector3 WobbleSpeed = new Vector3(0.5f, 0.5f, 0.5f);

	private Transform tr;

	private Vector3 BasePosition;

	private Vector3 NoiseIndex;

	private void Start()
	{
		tr = GetComponent("Transform") as Transform;
		BasePosition = tr.position;
		NoiseIndex.x = Random.value;
		NoiseIndex.y = Random.value;
		NoiseIndex.z = Random.value;
	}

	private void Update()
	{
		tr.Rotate(Time.deltaTime * RotateSpeed);
		Vector3 vector = default(Vector3);
		vector.x = Mathf.PerlinNoise(NoiseIndex.x, 0f) - 0.5f;
		vector.y = Mathf.PerlinNoise(NoiseIndex.y, 0f) - 0.5f;
		vector.z = Mathf.PerlinNoise(NoiseIndex.z, 0f) - 0.5f;
		vector.Scale(WobbleAmount);
		base.transform.position = BasePosition + vector;
		NoiseIndex += WobbleSpeed * Time.deltaTime;
	}
}
