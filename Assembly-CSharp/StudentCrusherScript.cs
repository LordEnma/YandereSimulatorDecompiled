using System;
using UnityEngine;

// Token: 0x0200044F RID: 1103
public class StudentCrusherScript : MonoBehaviour
{
	// Token: 0x06001D31 RID: 7473 RVA: 0x0015C64C File Offset: 0x0015A84C
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

	// Token: 0x04003583 RID: 13699
	public MechaScript Mecha;
}
