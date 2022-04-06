using System;
using UnityEngine;

// Token: 0x02000289 RID: 649
public class DistractionScript : MonoBehaviour
{
	// Token: 0x060013AA RID: 5034 RVA: 0x000B8A56 File Offset: 0x000B6C56
	private void Update()
	{
		if (this.Frame > 5)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		this.Frame++;
	}

	// Token: 0x060013AB RID: 5035 RVA: 0x000B8A7C File Offset: 0x000B6C7C
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

	// Token: 0x04001D30 RID: 7472
	private int Frame;
}
