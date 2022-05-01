using System;
using UnityEngine;

// Token: 0x0200044D RID: 1101
public class StealthBushScript : MonoBehaviour
{
	// Token: 0x06001D49 RID: 7497 RVA: 0x0015F514 File Offset: 0x0015D714
	private void OnTriggerEnter(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = true;
		}
	}

	// Token: 0x06001D4A RID: 7498 RVA: 0x0015F540 File Offset: 0x0015D740
	private void OnTriggerExit(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = false;
		}
	}
}
