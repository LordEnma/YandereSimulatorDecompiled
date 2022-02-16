using System;
using UnityEngine;

// Token: 0x02000446 RID: 1094
public class StealthBushScript : MonoBehaviour
{
	// Token: 0x06001D14 RID: 7444 RVA: 0x0015B764 File Offset: 0x00159964
	private void OnTriggerEnter(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = true;
		}
	}

	// Token: 0x06001D15 RID: 7445 RVA: 0x0015B790 File Offset: 0x00159990
	private void OnTriggerExit(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = false;
		}
	}
}
