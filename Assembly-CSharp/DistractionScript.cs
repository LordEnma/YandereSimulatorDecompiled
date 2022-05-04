using System;
using UnityEngine;

// Token: 0x02000289 RID: 649
public class DistractionScript : MonoBehaviour
{
	// Token: 0x060013AE RID: 5038 RVA: 0x000B903E File Offset: 0x000B723E
	private void Update()
	{
		if (this.Frame > 5)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		this.Frame++;
	}

	// Token: 0x060013AF RID: 5039 RVA: 0x000B9064 File Offset: 0x000B7264
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

	// Token: 0x04001D39 RID: 7481
	private int Frame;
}
