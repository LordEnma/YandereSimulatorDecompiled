using System;
using UnityEngine;

// Token: 0x02000442 RID: 1090
public class StealthBushScript : MonoBehaviour
{
	// Token: 0x06001CFC RID: 7420 RVA: 0x00158918 File Offset: 0x00156B18
	private void OnTriggerEnter(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = true;
		}
	}

	// Token: 0x06001CFD RID: 7421 RVA: 0x00158944 File Offset: 0x00156B44
	private void OnTriggerExit(Collider other)
	{
		StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
		if (component != null)
		{
			component.Hidden = false;
		}
	}
}
