using UnityEngine;

public class HairBladeScript : MonoBehaviour
{
	public GameObject FemaleBloodyScream;

	public GameObject MaleBloodyScream;

	public Vector3 PreviousPosition;

	public Collider MyCollider;

	public float Timer;

	public StudentScript Student;

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		GameObject gameObject = other.gameObject.transform.root.gameObject;
		if (gameObject.GetComponent<StudentScript>() != null)
		{
			Student = gameObject.GetComponent<StudentScript>();
			if (Student.StudentID != 1 && Student.Alive)
			{
				Student.DeathType = DeathType.EasterEgg;
				Object.Instantiate(Student.Male ? MaleBloodyScream : FemaleBloodyScream, Student.transform.position + Vector3.up, Quaternion.identity);
				Student.BecomeRagdoll();
				Student.Ragdoll.Dismember();
				GetComponent<AudioSource>().Play();
			}
		}
	}
}
