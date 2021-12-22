using System;
using UnityEngine;

// Token: 0x02000328 RID: 808
public class HomeYandereDetectorScript : MonoBehaviour
{
	// Token: 0x060018A0 RID: 6304 RVA: 0x000F1A51 File Offset: 0x000EFC51
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = true;
		}
	}

	// Token: 0x060018A1 RID: 6305 RVA: 0x000F1A6C File Offset: 0x000EFC6C
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = false;
		}
	}

	// Token: 0x04002571 RID: 9585
	public bool YandereDetected;
}
