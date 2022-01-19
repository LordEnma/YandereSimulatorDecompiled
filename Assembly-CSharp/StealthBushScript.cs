using System;
using UnityEngine;

// Token: 0x02000445 RID: 1093
public class StealthBushScript : MonoBehaviour
{
	// Token: 0x06001D0A RID: 7434 RVA: 0x0015AD80 File Offset: 0x00158F80
	private void OnTriggerEnter(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = true;
		}
	}

	// Token: 0x06001D0B RID: 7435 RVA: 0x0015ADAC File Offset: 0x00158FAC
	private void OnTriggerExit(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = false;
		}
	}
}
