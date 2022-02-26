using System;
using UnityEngine;

// Token: 0x0200034A RID: 842
public class KittenScript : MonoBehaviour
{
	// Token: 0x0600194B RID: 6475 RVA: 0x000FD684 File Offset: 0x000FB884
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

	// Token: 0x040027D0 RID: 10192
	public YandereScript Yandere;

	// Token: 0x040027D1 RID: 10193
	public GameObject Character;

	// Token: 0x040027D2 RID: 10194
	public string[] AnimationNames;

	// Token: 0x040027D3 RID: 10195
	public Transform Target;

	// Token: 0x040027D4 RID: 10196
	public Transform Head;

	// Token: 0x040027D5 RID: 10197
	public string CurrentAnim = string.Empty;

	// Token: 0x040027D6 RID: 10198
	public string IdleAnim = string.Empty;

	// Token: 0x040027D7 RID: 10199
	public bool Wait;

	// Token: 0x040027D8 RID: 10200
	public float Timer;
}
