using System;
using UnityEngine;

// Token: 0x02000451 RID: 1105
public class StudentCrusherScript : MonoBehaviour
{
	// Token: 0x06001D3D RID: 7485 RVA: 0x0015E7C8 File Offset: 0x0015C9C8
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

	// Token: 0x04003599 RID: 13721
	public MechaScript Mecha;
}
