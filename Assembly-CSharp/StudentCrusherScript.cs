using System;
using UnityEngine;

// Token: 0x02000457 RID: 1111
public class StudentCrusherScript : MonoBehaviour
{
	// Token: 0x06001D62 RID: 7522 RVA: 0x00161BB8 File Offset: 0x0015FDB8
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

	// Token: 0x04003624 RID: 13860
	public MechaScript Mecha;
}
