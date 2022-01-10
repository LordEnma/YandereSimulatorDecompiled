using System;
using UnityEngine;

// Token: 0x02000286 RID: 646
public class DistractionScript : MonoBehaviour
{
	// Token: 0x06001392 RID: 5010 RVA: 0x000B77F7 File Offset: 0x000B59F7
	private void Update()
	{
		if (this.Frame > 5)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		this.Frame++;
	}

	// Token: 0x06001393 RID: 5011 RVA: 0x000B781C File Offset: 0x000B5A1C
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

	// Token: 0x04001CFA RID: 7418
	private int Frame;
}
