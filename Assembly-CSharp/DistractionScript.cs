using System;
using UnityEngine;

// Token: 0x02000288 RID: 648
public class DistractionScript : MonoBehaviour
{
	// Token: 0x060013A4 RID: 5028 RVA: 0x000B894E File Offset: 0x000B6B4E
	private void Update()
	{
		if (this.Frame > 5)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		this.Frame++;
	}

	// Token: 0x060013A5 RID: 5029 RVA: 0x000B8974 File Offset: 0x000B6B74
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			EvilPhotographerScript component = other.gameObject.GetComponent<EvilPhotographerScript>();
			if (component != null)
			{
				component.DistractionPoint = base.transform.position;
				component.DistractionTimer = 5f;
				component.Distracted = true;
			}
		}
	}

	// Token: 0x04001D2E RID: 7470
	private int Frame;
}
