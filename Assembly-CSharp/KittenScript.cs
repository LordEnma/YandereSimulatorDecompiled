using System;
using UnityEngine;

// Token: 0x0200034D RID: 845
public class KittenScript : MonoBehaviour
{
	// Token: 0x0600196C RID: 6508 RVA: 0x000FF8AC File Offset: 0x000FDAAC
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

	// Token: 0x0400283B RID: 10299
	public YandereScript Yandere;

	// Token: 0x0400283C RID: 10300
	public GameObject Character;

	// Token: 0x0400283D RID: 10301
	public string[] AnimationNames;

	// Token: 0x0400283E RID: 10302
	public Transform Target;

	// Token: 0x0400283F RID: 10303
	public Transform Head;

	// Token: 0x04002840 RID: 10304
	public string CurrentAnim = string.Empty;

	// Token: 0x04002841 RID: 10305
	public string IdleAnim = string.Empty;

	// Token: 0x04002842 RID: 10306
	public bool Wait;

	// Token: 0x04002843 RID: 10307
	public float Timer;
}
