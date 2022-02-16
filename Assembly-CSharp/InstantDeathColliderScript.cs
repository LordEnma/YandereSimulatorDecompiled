using System;
using UnityEngine;

// Token: 0x02000337 RID: 823
public class InstantDeathColliderScript : MonoBehaviour
{
	// Token: 0x060018D9 RID: 6361 RVA: 0x000F5263 File Offset: 0x000F3463
	private void Update()
	{
		this.Frame++;
		if (this.Frame > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x060018DA RID: 6362 RVA: 0x000F5288 File Offset: 0x000F3488
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

	// Token: 0x0400262D RID: 9773
	public int Frame;
}
