using System;
using UnityEngine;

// Token: 0x02000454 RID: 1108
public class StudentCrusherScript : MonoBehaviour
{
	// Token: 0x06001D58 RID: 7512 RVA: 0x00160DF8 File Offset: 0x0015EFF8
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

	// Token: 0x04003607 RID: 13831
	public MechaScript Mecha;
}
