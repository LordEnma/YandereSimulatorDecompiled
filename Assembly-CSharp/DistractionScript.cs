using System;
using UnityEngine;

// Token: 0x02000286 RID: 646
public class DistractionScript : MonoBehaviour
{
	// Token: 0x06001393 RID: 5011 RVA: 0x000B7A7B File Offset: 0x000B5C7B
	private void Update()
	{
		if (this.Frame > 5)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		this.Frame++;
	}

	// Token: 0x06001394 RID: 5012 RVA: 0x000B7AA0 File Offset: 0x000B5CA0
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

	// Token: 0x04001D02 RID: 7426
	private int Frame;
}
