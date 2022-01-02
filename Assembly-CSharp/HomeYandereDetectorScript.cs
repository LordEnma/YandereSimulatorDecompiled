using System;
using UnityEngine;

// Token: 0x02000328 RID: 808
public class HomeYandereDetectorScript : MonoBehaviour
{
	// Token: 0x060018A2 RID: 6306 RVA: 0x000F1D05 File Offset: 0x000EFF05
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = true;
		}
	}

	// Token: 0x060018A3 RID: 6307 RVA: 0x000F1D20 File Offset: 0x000EFF20
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = false;
		}
	}

	// Token: 0x04002575 RID: 9589
	public bool YandereDetected;
}
