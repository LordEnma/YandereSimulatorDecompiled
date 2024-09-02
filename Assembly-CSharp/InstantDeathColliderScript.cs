using UnityEngine;

public class InstantDeathColliderScript : MonoBehaviour
{
	public GameObject ScorchMarks;

	public int Frame;

	private void Update()
	{
		Frame++;
		if (Frame > 1)
		{
			if (ScorchMarks != null)
			{
				ScorchMarks.SetActive(value: true);
			}
			Object.Destroy(base.gameObject);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null && !component.Struggling && !component.Attacked && component.StudentID > 1)
			{
				if (component.Rival)
				{
					component.StudentManager.RivalEliminated = true;
					component.StudentManager.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Accident;
					Debug.Log("Attempting to tell the game that the rival was murdered.");
				}
				component.NoScream = true;
				component.Combust();
				component.DeathType = DeathType.Explosion;
				component.BecomeRagdoll();
				Rigidbody obj = component.Ragdoll.AllRigidbodies[0];
				obj.isKinematic = false;
				Vector3 vector = obj.transform.position - base.transform.position;
				obj.AddForce(vector * 5000f);
			}
		}
		if (other.gameObject.layer == 13)
		{
			YandereScript component2 = other.gameObject.GetComponent<YandereScript>();
			if (component2 != null && !component2.Struggling && !component2.Attacking)
			{
				component2.StudentManager.Headmaster.Kill();
			}
		}
	}
}
