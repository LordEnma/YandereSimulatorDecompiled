using System;
using UnityEngine;

// Token: 0x02000329 RID: 809
public class HomeYandereDetectorScript : MonoBehaviour
{
	// Token: 0x060018A6 RID: 6310 RVA: 0x000F203D File Offset: 0x000F023D
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = true;
		}
	}

	// Token: 0x060018A7 RID: 6311 RVA: 0x000F2058 File Offset: 0x000F0258
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = false;
		}
	}

	// Token: 0x04002579 RID: 9593
	public bool YandereDetected;
}
