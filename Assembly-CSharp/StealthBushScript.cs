using System;
using UnityEngine;

// Token: 0x0200044C RID: 1100
public class StealthBushScript : MonoBehaviour
{
	// Token: 0x06001D3E RID: 7486 RVA: 0x0015E7F8 File Offset: 0x0015C9F8
	private void OnTriggerEnter(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = true;
		}
	}

	// Token: 0x06001D3F RID: 7487 RVA: 0x0015E824 File Offset: 0x0015CA24
	private void OnTriggerExit(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = false;
		}
	}
}
