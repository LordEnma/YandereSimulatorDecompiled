using System;
using UnityEngine;

// Token: 0x02000444 RID: 1092
public class StealthBushScript : MonoBehaviour
{
	// Token: 0x06001D08 RID: 7432 RVA: 0x001595E8 File Offset: 0x001577E8
	private void OnTriggerEnter(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = true;
		}
	}

	// Token: 0x06001D09 RID: 7433 RVA: 0x00159614 File Offset: 0x00157814
	private void OnTriggerExit(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = false;
		}
	}
}
