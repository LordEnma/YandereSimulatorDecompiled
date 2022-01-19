using System;
using UnityEngine;

// Token: 0x02000450 RID: 1104
public class StudentCrusherScript : MonoBehaviour
{
	// Token: 0x06001D33 RID: 7475 RVA: 0x0015DDE4 File Offset: 0x0015BFE4
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

	// Token: 0x04003589 RID: 13705
	public MechaScript Mecha;
}
