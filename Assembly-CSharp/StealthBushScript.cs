using System;
using UnityEngine;

// Token: 0x02000445 RID: 1093
public class StealthBushScript : MonoBehaviour
{
	// Token: 0x06001D0D RID: 7437 RVA: 0x0015B45C File Offset: 0x0015965C
	private void OnTriggerEnter(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = true;
		}
	}

	// Token: 0x06001D0E RID: 7438 RVA: 0x0015B488 File Offset: 0x00159688
	private void OnTriggerExit(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = false;
		}
	}
}
