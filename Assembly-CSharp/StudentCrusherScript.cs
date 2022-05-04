using System;
using UnityEngine;

// Token: 0x02000459 RID: 1113
public class StudentCrusherScript : MonoBehaviour
{
	// Token: 0x06001D74 RID: 7540 RVA: 0x00162BC0 File Offset: 0x00160DC0
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

	// Token: 0x04003642 RID: 13890
	public MechaScript Mecha;
}
