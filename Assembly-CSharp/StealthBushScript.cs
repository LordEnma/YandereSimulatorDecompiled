using System;
using UnityEngine;

// Token: 0x0200044B RID: 1099
public class StealthBushScript : MonoBehaviour
{
	// Token: 0x06001D37 RID: 7479 RVA: 0x0015E4D8 File Offset: 0x0015C6D8
	private void OnTriggerEnter(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = true;
		}
	}

	// Token: 0x06001D38 RID: 7480 RVA: 0x0015E504 File Offset: 0x0015C704
	private void OnTriggerExit(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = false;
		}
	}
}
