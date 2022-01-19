using System;
using UnityEngine;

// Token: 0x02000286 RID: 646
public class DistractionScript : MonoBehaviour
{
	// Token: 0x06001392 RID: 5010 RVA: 0x000B785B File Offset: 0x000B5A5B
	private void Update()
	{
		if (this.Frame > 5)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		this.Frame++;
	}

	// Token: 0x06001393 RID: 5011 RVA: 0x000B7880 File Offset: 0x000B5A80
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

	// Token: 0x04001CFC RID: 7420
	private int Frame;
}
