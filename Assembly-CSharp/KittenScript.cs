using System;
using UnityEngine;

// Token: 0x0200034C RID: 844
public class KittenScript : MonoBehaviour
{
	// Token: 0x06001966 RID: 6502 RVA: 0x000FF0A4 File Offset: 0x000FD2A4
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

	// Token: 0x0400282A RID: 10282
	public YandereScript Yandere;

	// Token: 0x0400282B RID: 10283
	public GameObject Character;

	// Token: 0x0400282C RID: 10284
	public string[] AnimationNames;

	// Token: 0x0400282D RID: 10285
	public Transform Target;

	// Token: 0x0400282E RID: 10286
	public Transform Head;

	// Token: 0x0400282F RID: 10287
	public string CurrentAnim = string.Empty;

	// Token: 0x04002830 RID: 10288
	public string IdleAnim = string.Empty;

	// Token: 0x04002831 RID: 10289
	public bool Wait;

	// Token: 0x04002832 RID: 10290
	public float Timer;
}
