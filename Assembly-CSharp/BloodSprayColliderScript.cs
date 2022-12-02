using UnityEngine;

public class BloodSprayColliderScript : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 13)
		{
			YandereScript component = other.gameObject.GetComponent<YandereScript>();
			if (component != null)
			{
				component.Bloodiness = 100f;
				Object.Destroy(base.gameObject);
			}
		}
	}
}
