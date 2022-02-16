using System;
using UnityEngine;

// Token: 0x02000349 RID: 841
public class KittenScript : MonoBehaviour
{
	// Token: 0x06001942 RID: 6466 RVA: 0x000FCD54 File Offset: 0x000FAF54
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

	// Token: 0x040027C1 RID: 10177
	public YandereScript Yandere;

	// Token: 0x040027C2 RID: 10178
	public GameObject Character;

	// Token: 0x040027C3 RID: 10179
	public string[] AnimationNames;

	// Token: 0x040027C4 RID: 10180
	public Transform Target;

	// Token: 0x040027C5 RID: 10181
	public Transform Head;

	// Token: 0x040027C6 RID: 10182
	public string CurrentAnim = string.Empty;

	// Token: 0x040027C7 RID: 10183
	public string IdleAnim = string.Empty;

	// Token: 0x040027C8 RID: 10184
	public bool Wait;

	// Token: 0x040027C9 RID: 10185
	public float Timer;
}
