using System;
using UnityEngine;

// Token: 0x020000EB RID: 235
public class BloodSprayColliderScript : MonoBehaviour
{
	// Token: 0x06000A45 RID: 2629 RVA: 0x0005B5A0 File Offset: 0x000597A0
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
