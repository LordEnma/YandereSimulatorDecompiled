using UnityEngine;

public class BounceScript : MonoBehaviour
{
	public float StartingMotion;

	public float DecliningSpeed;

	public float Motion;

	public float PositionX;

	public float Speed;

	public Transform MyCamera;

	public bool Go;

	private void Start()
	{
		StartingMotion += Random.Range(-0.001f, 0.001f);
		DecliningSpeed += Random.Range(-0.001f, 0.001f);
	}

	private void Update()
	{
		base.transform.position += new Vector3(0f, Motion, 0f);
		Motion -= Time.deltaTime * DecliningSpeed;
		if (base.transform.position.y < 0.5f)
		{
			Motion = StartingMotion;
		}
		if (MyCamera != null && Go)
		{
			Speed += Time.deltaTime;
			PositionX = Mathf.Lerp(PositionX, -0.999f, Time.deltaTime * Speed);
			MyCamera.position = new Vector3(PositionX, 1f, -10f);
		}
	}
}
