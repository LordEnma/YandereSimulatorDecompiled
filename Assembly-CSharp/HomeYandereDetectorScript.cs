using System;
using UnityEngine;

// Token: 0x02000329 RID: 809
public class HomeYandereDetectorScript : MonoBehaviour
{
	// Token: 0x060018A9 RID: 6313 RVA: 0x000F26F1 File Offset: 0x000F08F1
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = true;
		}
	}

	// Token: 0x060018AA RID: 6314 RVA: 0x000F270C File Offset: 0x000F090C
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = false;
		}
	}

	// Token: 0x04002585 RID: 9605
	public bool YandereDetected;
}
