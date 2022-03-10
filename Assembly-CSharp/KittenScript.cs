using System;
using UnityEngine;

// Token: 0x0200034A RID: 842
public class KittenScript : MonoBehaviour
{
	// Token: 0x0600194B RID: 6475 RVA: 0x000FD9C4 File Offset: 0x000FBBC4
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

	// Token: 0x040027E6 RID: 10214
	public YandereScript Yandere;

	// Token: 0x040027E7 RID: 10215
	public GameObject Character;

	// Token: 0x040027E8 RID: 10216
	public string[] AnimationNames;

	// Token: 0x040027E9 RID: 10217
	public Transform Target;

	// Token: 0x040027EA RID: 10218
	public Transform Head;

	// Token: 0x040027EB RID: 10219
	public string CurrentAnim = string.Empty;

	// Token: 0x040027EC RID: 10220
	public string IdleAnim = string.Empty;

	// Token: 0x040027ED RID: 10221
	public bool Wait;

	// Token: 0x040027EE RID: 10222
	public float Timer;
}
