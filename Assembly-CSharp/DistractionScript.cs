using System;
using UnityEngine;

// Token: 0x02000288 RID: 648
public class DistractionScript : MonoBehaviour
{
	// Token: 0x060013A0 RID: 5024 RVA: 0x000B8466 File Offset: 0x000B6666
	private void Update()
	{
		if (this.Frame > 5)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		this.Frame++;
	}

	// Token: 0x060013A1 RID: 5025 RVA: 0x000B848C File Offset: 0x000B668C
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

	// Token: 0x04001D1D RID: 7453
	private int Frame;
}
