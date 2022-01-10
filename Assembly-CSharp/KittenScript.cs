using System;
using UnityEngine;

// Token: 0x02000348 RID: 840
public class KittenScript : MonoBehaviour
{
	// Token: 0x06001938 RID: 6456 RVA: 0x000FC448 File Offset: 0x000FA648
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

	// Token: 0x040027AE RID: 10158
	public YandereScript Yandere;

	// Token: 0x040027AF RID: 10159
	public GameObject Character;

	// Token: 0x040027B0 RID: 10160
	public string[] AnimationNames;

	// Token: 0x040027B1 RID: 10161
	public Transform Target;

	// Token: 0x040027B2 RID: 10162
	public Transform Head;

	// Token: 0x040027B3 RID: 10163
	public string CurrentAnim = string.Empty;

	// Token: 0x040027B4 RID: 10164
	public string IdleAnim = string.Empty;

	// Token: 0x040027B5 RID: 10165
	public bool Wait;

	// Token: 0x040027B6 RID: 10166
	public float Timer;
}
