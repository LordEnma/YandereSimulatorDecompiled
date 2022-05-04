using System;
using UnityEngine;

// Token: 0x0200032D RID: 813
public class HomeYandereDetectorScript : MonoBehaviour
{
	// Token: 0x060018D2 RID: 6354 RVA: 0x000F4831 File Offset: 0x000F2A31
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = true;
		}
	}

	// Token: 0x060018D3 RID: 6355 RVA: 0x000F484C File Offset: 0x000F2A4C
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = false;
		}
	}

	// Token: 0x040025E6 RID: 9702
	public bool YandereDetected;
}
