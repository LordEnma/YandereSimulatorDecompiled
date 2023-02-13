using UnityEngine;

public class PhysicsActivatorScript : MonoBehaviour
{
	public int Frame;

	private void Start()
	{
	}

	private void Update()
	{
		if (Frame > 0)
		{
			Object.Destroy(base.gameObject);
		}
		Frame++;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!(other.gameObject.transform.parent == null) || other.gameObject.layer != 15)
		{
			return;
		}
		Debug.Log("A PhysicsActivator collided with something on the PickUp layer.");
		PickUpScript component = other.gameObject.GetComponent<PickUpScript>();
		if (component != null && component.enabled)
		{
			Debug.Log("Found a PickUpScript attached.");
			if (component.Yandere.PickUp != component)
			{
				if (component.transform.position != component.OriginalPosition)
				{
					Debug.Log("It's not in Ayano's hands. Telling it to Drop().");
					component.Drop();
				}
			}
			else
			{
				Debug.Log("It's in Ayano's hands. Ignoring it.");
			}
		}
		else
		{
			Debug.Log("Didn't find a PickUpScript attached.");
		}
		WeaponScript component2 = other.gameObject.GetComponent<WeaponScript>();
		if (component2 != null && component2.Yandere.EquippedWeapon != component2)
		{
			component2.Drop();
		}
	}
}
