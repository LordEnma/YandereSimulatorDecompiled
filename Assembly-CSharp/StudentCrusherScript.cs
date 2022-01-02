using System;
using UnityEngine;

// Token: 0x0200044D RID: 1101
public class StudentCrusherScript : MonoBehaviour
{
	// Token: 0x06001D27 RID: 7463 RVA: 0x0015BDC0 File Offset: 0x00159FC0
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.root.gameObject.layer == 9)
		{
			StudentScript component = other.transform.root.gameObject.GetComponent<StudentScript>();
			if (component != null && component.StudentID > 1)
			{
				if (this.Mecha.Speed > 0.9f)
				{
					UnityEngine.Object.Instantiate<GameObject>(component.BloodyScream, base.transform.position + Vector3.up, Quaternion.identity);
					component.BecomeRagdoll();
				}
				if (this.Mecha.Speed > 5f)
				{
					component.Ragdoll.Dismember();
				}
			}
		}
	}

	// Token: 0x0400356F RID: 13679
	public MechaScript Mecha;
}
