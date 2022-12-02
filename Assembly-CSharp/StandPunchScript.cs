using UnityEngine;

public class StandPunchScript : MonoBehaviour
{
	public Collider MyCollider;

	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			component.JojoReact();
		}
	}
}
