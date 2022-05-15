using System;
using UnityEngine;

// Token: 0x020000EC RID: 236
public class BloodSprayColliderScript : MonoBehaviour
{
	// Token: 0x06000A47 RID: 2631 RVA: 0x0005BACC File Offset: 0x00059CCC
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 13)
		{
			YandereScript component = other.gameObject.GetComponent<YandereScript>();
			if (component != null)
			{
				component.Bloodiness = 100f;
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}
}
