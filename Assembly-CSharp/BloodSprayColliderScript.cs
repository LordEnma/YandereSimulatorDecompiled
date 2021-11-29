using System;
using UnityEngine;

// Token: 0x020000EA RID: 234
public class BloodSprayColliderScript : MonoBehaviour
{
	// Token: 0x06000A42 RID: 2626 RVA: 0x0005B1C0 File Offset: 0x000593C0
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
