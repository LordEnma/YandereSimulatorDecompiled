using System;
using UnityEngine;

// Token: 0x0200032E RID: 814
public class HomeYandereDetectorScript : MonoBehaviour
{
	// Token: 0x060018D7 RID: 6359 RVA: 0x000F4CAD File Offset: 0x000F2EAD
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = true;
		}
	}

	// Token: 0x060018D8 RID: 6360 RVA: 0x000F4CC8 File Offset: 0x000F2EC8
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = false;
		}
	}

	// Token: 0x040025F4 RID: 9716
	public bool YandereDetected;
}
