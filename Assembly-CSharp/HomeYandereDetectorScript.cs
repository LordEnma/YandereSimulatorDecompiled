using System;
using UnityEngine;

// Token: 0x0200032B RID: 811
public class HomeYandereDetectorScript : MonoBehaviour
{
	// Token: 0x060018BE RID: 6334 RVA: 0x000F3971 File Offset: 0x000F1B71
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = true;
		}
	}

	// Token: 0x060018BF RID: 6335 RVA: 0x000F398C File Offset: 0x000F1B8C
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = false;
		}
	}

	// Token: 0x040025BF RID: 9663
	public bool YandereDetected;
}
