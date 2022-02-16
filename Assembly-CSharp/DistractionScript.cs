using System;
using UnityEngine;

// Token: 0x02000287 RID: 647
public class DistractionScript : MonoBehaviour
{
	// Token: 0x06001397 RID: 5015 RVA: 0x000B79BF File Offset: 0x000B5BBF
	private void Update()
	{
		if (this.Frame > 5)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		this.Frame++;
	}

	// Token: 0x06001398 RID: 5016 RVA: 0x000B79E4 File Offset: 0x000B5BE4
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

	// Token: 0x04001D05 RID: 7429
	private int Frame;
}
