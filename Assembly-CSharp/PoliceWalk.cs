using UnityEngine;

public class PoliceWalk : MonoBehaviour
{
	private void Update()
	{
		Vector3 position = base.transform.position;
		position.z += Time.deltaTime;
		base.transform.position = position;
	}
}
