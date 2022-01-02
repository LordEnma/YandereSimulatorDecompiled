using System;
using UnityEngine;

// Token: 0x02000335 RID: 821
public class InstantDeathColliderScript : MonoBehaviour
{
	// Token: 0x060018CB RID: 6347 RVA: 0x000F464B File Offset: 0x000F284B
	private void Update()
	{
		this.Frame++;
		if (this.Frame > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x060018CC RID: 6348 RVA: 0x000F4670 File Offset: 0x000F2870
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null && component.StudentID > 1)
			{
				if (component.Rival)
				{
					component.StudentManager.RivalEliminated = true;
					component.StudentManager.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Accident;
					Debug.Log("Attempting to tell the game that the rival was murdered.");
				}
				component.DeathType = DeathType.Explosion;
				component.BecomeRagdoll();
				Rigidbody rigidbody = component.Ragdoll.AllRigidbodies[0];
				rigidbody.isKinematic = false;
				Vector3 a = rigidbody.transform.position - base.transform.position;
				rigidbody.AddForce(a * 5000f);
			}
		}
	}

	// Token: 0x04002616 RID: 9750
	public int Frame;
}
