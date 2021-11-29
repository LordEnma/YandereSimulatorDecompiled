using System;
using UnityEngine;

// Token: 0x02000441 RID: 1089
public class StealthBushScript : MonoBehaviour
{
	// Token: 0x06001CF4 RID: 7412 RVA: 0x00157FF4 File Offset: 0x001561F4
	private void OnTriggerEnter(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = true;
		}
	}

	// Token: 0x06001CF5 RID: 7413 RVA: 0x00158020 File Offset: 0x00156220
	private void OnTriggerExit(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = false;
		}
	}
}
