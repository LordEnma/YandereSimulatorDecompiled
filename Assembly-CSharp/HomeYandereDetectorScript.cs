using System;
using UnityEngine;

// Token: 0x0200032B RID: 811
public class HomeYandereDetectorScript : MonoBehaviour
{
	// Token: 0x060018B9 RID: 6329 RVA: 0x000F3179 File Offset: 0x000F1379
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = true;
		}
	}

	// Token: 0x060018BA RID: 6330 RVA: 0x000F3194 File Offset: 0x000F1394
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = false;
		}
	}

	// Token: 0x0400259A RID: 9626
	public bool YandereDetected;
}
