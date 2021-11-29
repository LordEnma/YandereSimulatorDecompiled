using System;
using UnityEngine;

// Token: 0x02000247 RID: 583
public class CirnoIceAttackScript : MonoBehaviour
{
	// Token: 0x06001250 RID: 4688 RVA: 0x0008C921 File Offset: 0x0008AB21
	private void Start()
	{
		Physics.IgnoreLayerCollision(18, 13, true);
		Physics.IgnoreLayerCollision(18, 18, true);
	}

	// Token: 0x06001251 RID: 4689 RVA: 0x0008C938 File Offset: 0x0008AB38
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

	// Token: 0x0400171C RID: 5916
	public GameObject IceExplosion;
}
