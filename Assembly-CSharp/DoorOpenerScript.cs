using UnityEngine;

public class DoorOpenerScript : MonoBehaviour
{
	public StudentScript Student;

	public DoorScript Door;

	private void Start()
	{
		base.gameObject.layer = 1;
		BoxCollider component = GetComponent<BoxCollider>();
		if (component.size.y >= 0.5f)
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, 0.15f, base.transform.localPosition.z);
			component.size = new Vector3(component.size.x, 0.3f, component.size.y);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			Student = other.gameObject.GetComponent<StudentScript>();
			if (Student != null && !Student.Dying && !Door.Open && !Door.Locked)
			{
				Door.Student = Student;
				Door.OpenDoor();
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (!Door.Open && other.gameObject.layer == 9)
		{
			Student = other.gameObject.GetComponent<StudentScript>();
			if (Student != null && !Student.Dying && !Door.Open && !Door.Locked)
			{
				Door.Student = Student;
				Door.OpenDoor();
			}
		}
	}
}
