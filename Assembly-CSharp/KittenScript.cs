using System;
using UnityEngine;

// Token: 0x0200034D RID: 845
public class KittenScript : MonoBehaviour
{
	// Token: 0x0600196D RID: 6509 RVA: 0x000FFAB0 File Offset: 0x000FDCB0
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

	// Token: 0x04002842 RID: 10306
	public YandereScript Yandere;

	// Token: 0x04002843 RID: 10307
	public GameObject Character;

	// Token: 0x04002844 RID: 10308
	public string[] AnimationNames;

	// Token: 0x04002845 RID: 10309
	public Transform Target;

	// Token: 0x04002846 RID: 10310
	public Transform Head;

	// Token: 0x04002847 RID: 10311
	public string CurrentAnim = string.Empty;

	// Token: 0x04002848 RID: 10312
	public string IdleAnim = string.Empty;

	// Token: 0x04002849 RID: 10313
	public bool Wait;

	// Token: 0x0400284A RID: 10314
	public float Timer;
}
