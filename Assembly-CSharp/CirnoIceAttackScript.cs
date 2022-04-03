using System;
using UnityEngine;

// Token: 0x02000248 RID: 584
public class CirnoIceAttackScript : MonoBehaviour
{
	// Token: 0x06001256 RID: 4694 RVA: 0x0008D329 File Offset: 0x0008B529
	private void Start()
	{
		Physics.IgnoreLayerCollision(18, 13, true);
		Physics.IgnoreLayerCollision(18, 18, true);
	}

	// Token: 0x06001257 RID: 4695 RVA: 0x0008D340 File Offset: 0x0008B540
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

	// Token: 0x04001734 RID: 5940
	public GameObject IceExplosion;
}
