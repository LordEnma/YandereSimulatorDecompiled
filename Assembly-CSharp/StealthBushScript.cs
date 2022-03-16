using System;
using UnityEngine;

// Token: 0x02000448 RID: 1096
public class StealthBushScript : MonoBehaviour
{
	// Token: 0x06001D2D RID: 7469 RVA: 0x0015D944 File Offset: 0x0015BB44
	private void OnTriggerEnter(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = true;
		}
	}

	// Token: 0x06001D2E RID: 7470 RVA: 0x0015D970 File Offset: 0x0015BB70
	private void OnTriggerExit(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = false;
		}
	}
}
