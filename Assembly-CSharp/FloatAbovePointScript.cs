using UnityEngine;

public class FloatAbovePointScript : MonoBehaviour
{
	public Transform Target;

	private void Update()
	{
		base.transform.position = Target.position + new Vector3(0f, 0.15f, 0f);
	}
}
