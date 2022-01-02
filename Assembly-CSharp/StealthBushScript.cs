using System;
using UnityEngine;

// Token: 0x02000442 RID: 1090
public class StealthBushScript : MonoBehaviour
{
	// Token: 0x06001CFE RID: 7422 RVA: 0x00158D5C File Offset: 0x00156F5C
	private void OnTriggerEnter(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = true;
		}
	}

	// Token: 0x06001CFF RID: 7423 RVA: 0x00158D88 File Offset: 0x00156F88
	private void OnTriggerExit(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = false;
		}
	}
}
