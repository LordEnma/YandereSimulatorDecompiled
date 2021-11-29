using System;
using UnityEngine;

// Token: 0x0200044C RID: 1100
public class StudentCrusherScript : MonoBehaviour
{
	// Token: 0x06001D1D RID: 7453 RVA: 0x0015AFA4 File Offset: 0x001591A4
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

	// Token: 0x0400353D RID: 13629
	public MechaScript Mecha;
}
