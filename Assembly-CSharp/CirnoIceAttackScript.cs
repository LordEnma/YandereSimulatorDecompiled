using System;
using UnityEngine;

// Token: 0x02000249 RID: 585
public class CirnoIceAttackScript : MonoBehaviour
{
	// Token: 0x06001258 RID: 4696 RVA: 0x0008D8C5 File Offset: 0x0008BAC5
	private void Start()
	{
		Physics.IgnoreLayerCollision(18, 13, true);
		Physics.IgnoreLayerCollision(18, 18, true);
	}

	// Token: 0x06001259 RID: 4697 RVA: 0x0008D8DC File Offset: 0x0008BADC
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

	// Token: 0x0400173D RID: 5949
	public GameObject IceExplosion;
}
