using System;
using UnityEngine;

// Token: 0x02000289 RID: 649
public class DistractionScript : MonoBehaviour
{
	// Token: 0x060013AA RID: 5034 RVA: 0x000B8BDA File Offset: 0x000B6DDA
	private void Update()
	{
		if (this.Frame > 5)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		this.Frame++;
	}

	// Token: 0x060013AB RID: 5035 RVA: 0x000B8C00 File Offset: 0x000B6E00
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

	// Token: 0x04001D31 RID: 7473
	private int Frame;
}
