using System;
using UnityEngine;

// Token: 0x02000329 RID: 809
public class HomeYandereDetectorScript : MonoBehaviour
{
	// Token: 0x060018A7 RID: 6311 RVA: 0x000F254D File Offset: 0x000F074D
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = true;
		}
	}

	// Token: 0x060018A8 RID: 6312 RVA: 0x000F2568 File Offset: 0x000F0768
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = false;
		}
	}

	// Token: 0x04002581 RID: 9601
	public bool YandereDetected;
}
