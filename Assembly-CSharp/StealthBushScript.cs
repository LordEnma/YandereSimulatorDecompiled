using System;
using UnityEngine;

// Token: 0x0200044E RID: 1102
public class StealthBushScript : MonoBehaviour
{
	// Token: 0x06001D50 RID: 7504 RVA: 0x00160450 File Offset: 0x0015E650
	private void OnTriggerEnter(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = true;
		}
	}

	// Token: 0x06001D51 RID: 7505 RVA: 0x0016047C File Offset: 0x0015E67C
	private void OnTriggerExit(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = false;
		}
	}
}
