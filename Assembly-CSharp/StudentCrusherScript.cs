using UnityEngine;

public class StudentCrusherScript : MonoBehaviour
{
	public MechaScript Mecha;

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.root.gameObject.layer != 9)
		{
			return;
		}
		StudentScript component = other.transform.root.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			if (Mecha.Speed > 0.9f)
			{
				Object.Instantiate(component.BloodyScream, base.transform.position + Vector3.up, Quaternion.identity);
				component.BecomeRagdoll();
			}
			if (Mecha.Speed > 5f)
			{
				component.Ragdoll.Dismember();
			}
		}
	}
}
