using UnityEngine;

public class HeadCollisionDetectionScript : MonoBehaviour
{
	public Collider MyCollider;

	public bool Clipping;

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 0)
		{
			Debug.Log("Apparently, Ayano's head is currently clipping into a " + other.gameObject.name + ".");
			if (other.gameObject.transform.parent != null)
			{
				Debug.Log("The " + other.gameObject.name + "'s parent is named " + other.gameObject.transform.parent.gameObject.name);
			}
			Clipping = true;
		}
	}
}
