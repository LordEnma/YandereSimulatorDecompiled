using System;
using UnityEngine;

// Token: 0x0200032C RID: 812
public class HomeYandereDetectorScript : MonoBehaviour
{
	// Token: 0x060018C4 RID: 6340 RVA: 0x000F3FCD File Offset: 0x000F21CD
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = true;
		}
	}

	// Token: 0x060018C5 RID: 6341 RVA: 0x000F3FE8 File Offset: 0x000F21E8
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = false;
		}
	}

	// Token: 0x040025D2 RID: 9682
	public bool YandereDetected;
}
