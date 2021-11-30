using System;
using UnityEngine;

// Token: 0x02000346 RID: 838
public class KittenScript : MonoBehaviour
{
	// Token: 0x0600192B RID: 6443 RVA: 0x000FB618 File Offset: 0x000F9818
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

	// Token: 0x04002781 RID: 10113
	public YandereScript Yandere;

	// Token: 0x04002782 RID: 10114
	public GameObject Character;

	// Token: 0x04002783 RID: 10115
	public string[] AnimationNames;

	// Token: 0x04002784 RID: 10116
	public Transform Target;

	// Token: 0x04002785 RID: 10117
	public Transform Head;

	// Token: 0x04002786 RID: 10118
	public string CurrentAnim = string.Empty;

	// Token: 0x04002787 RID: 10119
	public string IdleAnim = string.Empty;

	// Token: 0x04002788 RID: 10120
	public bool Wait;

	// Token: 0x04002789 RID: 10121
	public float Timer;
}
