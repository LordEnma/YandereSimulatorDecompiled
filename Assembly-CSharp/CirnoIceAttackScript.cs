using System;
using UnityEngine;

// Token: 0x02000248 RID: 584
public class CirnoIceAttackScript : MonoBehaviour
{
	// Token: 0x06001253 RID: 4691 RVA: 0x0008CB05 File Offset: 0x0008AD05
	private void Start()
	{
		Physics.IgnoreLayerCollision(18, 13, true);
		Physics.IgnoreLayerCollision(18, 18, true);
	}

	// Token: 0x06001254 RID: 4692 RVA: 0x0008CB1C File Offset: 0x0008AD1C
	private void OnCollisionEnter(Collision collision)
	{
		UnityEngine.Object.Instantiate<GameObject>(this.IceExplosion, base.transform.position, Quaternion.identity);
		if (collision.gameObject.layer == 9)
		{
			StudentScript component = collision.gameObject.GetComponent<StudentScript>();
			if (component != null && component.StudentID != 1)
			{
				component.SpawnAlarmDisc();
				component.BecomeRagdoll();
			}
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}

	// Token: 0x04001720 RID: 5920
	public GameObject IceExplosion;
}
