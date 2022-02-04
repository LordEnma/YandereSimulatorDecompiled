using System;
using UnityEngine;

// Token: 0x02000329 RID: 809
public class HomeYandereDetectorScript : MonoBehaviour
{
	// Token: 0x060018A7 RID: 6311 RVA: 0x000F2605 File Offset: 0x000F0805
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = true;
		}
	}

	// Token: 0x060018A8 RID: 6312 RVA: 0x000F2620 File Offset: 0x000F0820
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = false;
		}
	}

	// Token: 0x04002582 RID: 9602
	public bool YandereDetected;
}
