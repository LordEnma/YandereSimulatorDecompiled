using System;
using UnityEngine;

// Token: 0x02000452 RID: 1106
public class StudentCrusherScript : MonoBehaviour
{
	// Token: 0x06001D48 RID: 7496 RVA: 0x0015F8A8 File Offset: 0x0015DAA8
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

	// Token: 0x040035C0 RID: 13760
	public MechaScript Mecha;
}
