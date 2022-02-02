using System;
using UnityEngine;

// Token: 0x02000445 RID: 1093
public class StealthBushScript : MonoBehaviour
{
	// Token: 0x06001D0B RID: 7435 RVA: 0x0015B1C0 File Offset: 0x001593C0
	private void OnTriggerEnter(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = true;
		}
	}

	// Token: 0x06001D0C RID: 7436 RVA: 0x0015B1EC File Offset: 0x001593EC
	private void OnTriggerExit(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = false;
		}
	}
}
