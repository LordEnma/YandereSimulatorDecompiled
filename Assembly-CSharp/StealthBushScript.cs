using System;
using UnityEngine;

// Token: 0x0200044E RID: 1102
public class StealthBushScript : MonoBehaviour
{
	// Token: 0x06001D4F RID: 7503 RVA: 0x00160194 File Offset: 0x0015E394
	private void OnTriggerEnter(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = true;
		}
	}

	// Token: 0x06001D50 RID: 7504 RVA: 0x001601C0 File Offset: 0x0015E3C0
	private void OnTriggerExit(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = false;
		}
	}
}
