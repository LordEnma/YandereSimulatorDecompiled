using System;
using UnityEngine;

// Token: 0x02000447 RID: 1095
public class StealthBushScript : MonoBehaviour
{
	// Token: 0x06001D1D RID: 7453 RVA: 0x0015C210 File Offset: 0x0015A410
	private void OnTriggerEnter(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = true;
		}
	}

	// Token: 0x06001D1E RID: 7454 RVA: 0x0015C23C File Offset: 0x0015A43C
	private void OnTriggerExit(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = false;
		}
	}
}
