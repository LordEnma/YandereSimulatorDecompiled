using System;
using UnityEngine;

// Token: 0x0200044D RID: 1101
public class StudentCrusherScript : MonoBehaviour
{
	// Token: 0x06001D25 RID: 7461 RVA: 0x0015B97C File Offset: 0x00159B7C
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

	// Token: 0x04003568 RID: 13672
	public MechaScript Mecha;
}
