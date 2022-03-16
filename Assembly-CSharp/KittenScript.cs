using System;
using UnityEngine;

// Token: 0x0200034A RID: 842
public class KittenScript : MonoBehaviour
{
	// Token: 0x06001952 RID: 6482 RVA: 0x000FE180 File Offset: 0x000FC380
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

	// Token: 0x04002803 RID: 10243
	public YandereScript Yandere;

	// Token: 0x04002804 RID: 10244
	public GameObject Character;

	// Token: 0x04002805 RID: 10245
	public string[] AnimationNames;

	// Token: 0x04002806 RID: 10246
	public Transform Target;

	// Token: 0x04002807 RID: 10247
	public Transform Head;

	// Token: 0x04002808 RID: 10248
	public string CurrentAnim = string.Empty;

	// Token: 0x04002809 RID: 10249
	public string IdleAnim = string.Empty;

	// Token: 0x0400280A RID: 10250
	public bool Wait;

	// Token: 0x0400280B RID: 10251
	public float Timer;
}
