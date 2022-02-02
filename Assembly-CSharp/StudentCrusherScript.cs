using System;
using UnityEngine;

// Token: 0x02000450 RID: 1104
public class StudentCrusherScript : MonoBehaviour
{
	// Token: 0x06001D34 RID: 7476 RVA: 0x0015E224 File Offset: 0x0015C424
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

	// Token: 0x0400358F RID: 13711
	public MechaScript Mecha;
}
