using System;
using UnityEngine;

// Token: 0x0200028A RID: 650
public class DistractionScript : MonoBehaviour
{
	// Token: 0x060013B0 RID: 5040 RVA: 0x000B934A File Offset: 0x000B754A
	private void Update()
	{
		if (this.Frame > 5)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		this.Frame++;
	}

	// Token: 0x060013B1 RID: 5041 RVA: 0x000B9370 File Offset: 0x000B7570
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

	// Token: 0x04001D40 RID: 7488
	private int Frame;
}
