using System;
using UnityEngine;

// Token: 0x0200033A RID: 826
public class InstantDeathColliderScript : MonoBehaviour
{
	// Token: 0x060018F4 RID: 6388 RVA: 0x000F6C9B File Offset: 0x000F4E9B
	private void Update()
	{
		this.Frame++;
		if (this.Frame > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x060018F5 RID: 6389 RVA: 0x000F6CC0 File Offset: 0x000F4EC0
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

	// Token: 0x0400267D RID: 9853
	public int Frame;
}
