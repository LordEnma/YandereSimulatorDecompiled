using UnityEngine;

public class DrillScript : MonoBehaviour
{
	private void LateUpdate()
	{
		base.transform.Rotate(Vector3.up * Time.deltaTime * 3600f);
	}
}
