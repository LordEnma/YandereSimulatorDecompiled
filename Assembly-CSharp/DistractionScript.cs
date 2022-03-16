using System;
using UnityEngine;

// Token: 0x02000288 RID: 648
public class DistractionScript : MonoBehaviour
{
	// Token: 0x060013A3 RID: 5027 RVA: 0x000B8842 File Offset: 0x000B6A42
	private void Update()
	{
		if (this.Frame > 5)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		this.Frame++;
	}

	// Token: 0x060013A4 RID: 5028 RVA: 0x000B8868 File Offset: 0x000B6A68
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

	// Token: 0x04001D2B RID: 7467
	private int Frame;
}
