using System;
using UnityEngine;

// Token: 0x0200034B RID: 843
public class KittenScript : MonoBehaviour
{
	// Token: 0x06001958 RID: 6488 RVA: 0x000FE80C File Offset: 0x000FCA0C
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

	// Token: 0x04002816 RID: 10262
	public YandereScript Yandere;

	// Token: 0x04002817 RID: 10263
	public GameObject Character;

	// Token: 0x04002818 RID: 10264
	public string[] AnimationNames;

	// Token: 0x04002819 RID: 10265
	public Transform Target;

	// Token: 0x0400281A RID: 10266
	public Transform Head;

	// Token: 0x0400281B RID: 10267
	public string CurrentAnim = string.Empty;

	// Token: 0x0400281C RID: 10268
	public string IdleAnim = string.Empty;

	// Token: 0x0400281D RID: 10269
	public bool Wait;

	// Token: 0x0400281E RID: 10270
	public float Timer;
}
