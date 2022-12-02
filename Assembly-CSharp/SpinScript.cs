using UnityEngine;

public class SpinScript : MonoBehaviour
{
	public float X;

	public float Y;

	public float Z;

	private float RotationX;

	private float RotationY;

	private float RotationZ;

	private void Update()
	{
		RotationX += X * Time.deltaTime;
		RotationY += Y * Time.deltaTime;
		RotationZ += Z * Time.deltaTime;
		base.transform.localEulerAngles = new Vector3(RotationX, RotationY, RotationZ);
	}
}
