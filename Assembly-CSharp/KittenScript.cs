using System;
using UnityEngine;

// Token: 0x0200034C RID: 844
public class KittenScript : MonoBehaviour
{
	// Token: 0x06001962 RID: 6498 RVA: 0x000FEBA0 File Offset: 0x000FCDA0
	private void LateUpdate()
	{
		if (Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 5f)
		{
			if (!this.Yandere.Aiming)
			{
				Vector3 b = (this.Yandere.Head.transform.position.x < base.transform.position.x) ? this.Yandere.Head.transform.position : (base.transform.position + base.transform.forward + base.transform.up * 0.139854f);
				this.Target.position = Vector3.Lerp(this.Target.position, b, Time.deltaTime * 5f);
				this.Head.transform.LookAt(this.Target);
				return;
			}
			this.Head.transform.LookAt(this.Yandere.transform.position + Vector3.up * this.Head.position.y);
		}
	}

	// Token: 0x04002821 RID: 10273
	public YandereScript Yandere;

	// Token: 0x04002822 RID: 10274
	public GameObject Character;

	// Token: 0x04002823 RID: 10275
	public string[] AnimationNames;

	// Token: 0x04002824 RID: 10276
	public Transform Target;

	// Token: 0x04002825 RID: 10277
	public Transform Head;

	// Token: 0x04002826 RID: 10278
	public string CurrentAnim = string.Empty;

	// Token: 0x04002827 RID: 10279
	public string IdleAnim = string.Empty;

	// Token: 0x04002828 RID: 10280
	public bool Wait;

	// Token: 0x04002829 RID: 10281
	public float Timer;
}
