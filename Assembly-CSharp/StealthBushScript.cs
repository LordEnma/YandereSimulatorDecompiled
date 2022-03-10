using System;
using UnityEngine;

// Token: 0x02000447 RID: 1095
public class StealthBushScript : MonoBehaviour
{
	// Token: 0x06001D1F RID: 7455 RVA: 0x0015C794 File Offset: 0x0015A994
	private void OnTriggerEnter(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = true;
		}
	}

	// Token: 0x06001D20 RID: 7456 RVA: 0x0015C7C0 File Offset: 0x0015A9C0
	private void OnTriggerExit(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = false;
		}
	}
}
