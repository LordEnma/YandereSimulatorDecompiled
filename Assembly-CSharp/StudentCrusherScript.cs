using System;
using UnityEngine;

// Token: 0x0200045A RID: 1114
public class StudentCrusherScript : MonoBehaviour
{
	// Token: 0x06001D7A RID: 7546 RVA: 0x00163874 File Offset: 0x00161A74
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

	// Token: 0x04003657 RID: 13911
	public MechaScript Mecha;
}
