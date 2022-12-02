using UnityEngine;

public class ForceRotationScript : MonoBehaviour
{
	public float X;

	public float Y;

	public float Z;

	private void LateUpdate()
	{
		base.transform.eulerAngles = new Vector3(X, Y, Z);
	}
}
