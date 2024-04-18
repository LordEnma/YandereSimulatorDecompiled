using UnityEngine;

public class DisableRigidbodiesScript : MonoBehaviour
{
	public float Timer;

	public int ID;

	private void Start()
	{
		if (ID == 1)
		{
			IterateThroughAllChildren(base.transform);
		}
	}

	private void Update()
	{
		Timer += Time.deltaTime;
		if (!(Timer > 5f))
		{
			return;
		}
		foreach (Transform item in base.transform)
		{
			Rigidbody component = item.GetComponent<Rigidbody>();
			if (component != null)
			{
				component.isKinematic = true;
				component.useGravity = false;
			}
			Collider component2 = item.GetComponent<Collider>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
		}
		base.enabled = false;
	}

	private void IterateThroughAllChildren(Transform parentTransform)
	{
		foreach (Transform item in parentTransform)
		{
			Rigidbody component = item.GetComponent<Rigidbody>();
			if (component != null)
			{
				component.isKinematic = true;
				component.useGravity = false;
			}
			Collider component2 = item.GetComponent<Collider>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			IterateThroughAllChildren(item);
		}
	}
}
