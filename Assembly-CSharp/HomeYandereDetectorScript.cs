using System;
using UnityEngine;

// Token: 0x0200032D RID: 813
public class HomeYandereDetectorScript : MonoBehaviour
{
	// Token: 0x060018CE RID: 6350 RVA: 0x000F4361 File Offset: 0x000F2561
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = true;
		}
	}

	// Token: 0x060018CF RID: 6351 RVA: 0x000F437C File Offset: 0x000F257C
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = false;
		}
	}

	// Token: 0x040025DD RID: 9693
	public bool YandereDetected;
}
