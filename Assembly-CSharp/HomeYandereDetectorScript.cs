using System;
using UnityEngine;

// Token: 0x0200032D RID: 813
public class HomeYandereDetectorScript : MonoBehaviour
{
	// Token: 0x060018CA RID: 6346 RVA: 0x000F40CD File Offset: 0x000F22CD
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = true;
		}
	}

	// Token: 0x060018CB RID: 6347 RVA: 0x000F40E8 File Offset: 0x000F22E8
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = false;
		}
	}

	// Token: 0x040025D5 RID: 9685
	public bool YandereDetected;
}
