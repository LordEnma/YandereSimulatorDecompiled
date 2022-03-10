using System;
using UnityEngine;

// Token: 0x0200032B RID: 811
public class HomeYandereDetectorScript : MonoBehaviour
{
	// Token: 0x060018B9 RID: 6329 RVA: 0x000F34B1 File Offset: 0x000F16B1
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = true;
		}
	}

	// Token: 0x060018BA RID: 6330 RVA: 0x000F34CC File Offset: 0x000F16CC
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = false;
		}
	}

	// Token: 0x040025AE RID: 9646
	public bool YandereDetected;
}
