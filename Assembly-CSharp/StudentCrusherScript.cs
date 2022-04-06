using System;
using UnityEngine;

// Token: 0x02000458 RID: 1112
public class StudentCrusherScript : MonoBehaviour
{
	// Token: 0x06001D69 RID: 7529 RVA: 0x00161ED8 File Offset: 0x001600D8
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

	// Token: 0x04003627 RID: 13863
	public MechaScript Mecha;
}
