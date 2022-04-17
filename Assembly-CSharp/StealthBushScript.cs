using System;
using UnityEngine;

// Token: 0x0200044C RID: 1100
public class StealthBushScript : MonoBehaviour
{
	// Token: 0x06001D42 RID: 7490 RVA: 0x0015EC84 File Offset: 0x0015CE84
	private void OnTriggerEnter(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = true;
		}
	}

	// Token: 0x06001D43 RID: 7491 RVA: 0x0015ECB0 File Offset: 0x0015CEB0
	private void OnTriggerExit(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = false;
		}
	}
}
