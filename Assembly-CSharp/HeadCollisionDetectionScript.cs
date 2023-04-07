using UnityEngine;

public class HeadCollisionDetectionScript : MonoBehaviour
{
	public Collider MyCollider;

	public bool Clipping;

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 0)
		{
			Clipping = true;
		}
	}
}
