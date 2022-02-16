using System;
using UnityEngine;

// Token: 0x02000248 RID: 584
public class CirnoIceAttackScript : MonoBehaviour
{
	// Token: 0x06001254 RID: 4692 RVA: 0x0008CC69 File Offset: 0x0008AE69
	private void Start()
	{
		Physics.IgnoreLayerCollision(18, 13, true);
		Physics.IgnoreLayerCollision(18, 18, true);
	}

	// Token: 0x06001255 RID: 4693 RVA: 0x0008CC80 File Offset: 0x0008AE80
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

	// Token: 0x04001724 RID: 5924
	public GameObject IceExplosion;
}
