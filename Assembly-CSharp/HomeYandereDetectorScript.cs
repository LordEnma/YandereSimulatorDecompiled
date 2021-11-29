using System;
using UnityEngine;

// Token: 0x02000327 RID: 807
public class HomeYandereDetectorScript : MonoBehaviour
{
	// Token: 0x06001899 RID: 6297 RVA: 0x000F1261 File Offset: 0x000EF461
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = true;
		}
	}

	// Token: 0x0600189A RID: 6298 RVA: 0x000F127C File Offset: 0x000EF47C
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = false;
		}
	}

	// Token: 0x04002551 RID: 9553
	public bool YandereDetected;
}
