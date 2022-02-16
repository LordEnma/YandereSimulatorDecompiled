using System;
using UnityEngine;

// Token: 0x0200032A RID: 810
public class HomeYandereDetectorScript : MonoBehaviour
{
	// Token: 0x060018B0 RID: 6320 RVA: 0x000F2895 File Offset: 0x000F0A95
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = true;
		}
	}

	// Token: 0x060018B1 RID: 6321 RVA: 0x000F28B0 File Offset: 0x000F0AB0
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = false;
		}
	}

	// Token: 0x0400258B RID: 9611
	public bool YandereDetected;
}
