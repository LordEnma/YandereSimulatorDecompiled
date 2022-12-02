using UnityEngine;

public class SmoothLookAtScript : MonoBehaviour
{
	public Transform Target;

	public float Speed;

	private void LateUpdate()
	{
		Quaternion b = Quaternion.LookRotation(Target.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * Speed);
	}
}
