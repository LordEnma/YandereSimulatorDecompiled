using UnityEngine;

public class ScrollAndTeleportScript : MonoBehaviour
{
	public float Speed;

	public float Limit;

	public float Distance;

	private void Update()
	{
		base.transform.position -= new Vector3(0f, 0f, Speed * Time.deltaTime);
		if (base.transform.position.z < Limit)
		{
			base.transform.position += new Vector3(0f, 0f, Distance);
		}
	}
}
