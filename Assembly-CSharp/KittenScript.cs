using System;
using UnityEngine;

// Token: 0x02000348 RID: 840
public class KittenScript : MonoBehaviour
{
	// Token: 0x06001939 RID: 6457 RVA: 0x000FC9E8 File Offset: 0x000FABE8
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

	// Token: 0x040027B7 RID: 10167
	public YandereScript Yandere;

	// Token: 0x040027B8 RID: 10168
	public GameObject Character;

	// Token: 0x040027B9 RID: 10169
	public string[] AnimationNames;

	// Token: 0x040027BA RID: 10170
	public Transform Target;

	// Token: 0x040027BB RID: 10171
	public Transform Head;

	// Token: 0x040027BC RID: 10172
	public string CurrentAnim = string.Empty;

	// Token: 0x040027BD RID: 10173
	public string IdleAnim = string.Empty;

	// Token: 0x040027BE RID: 10174
	public bool Wait;

	// Token: 0x040027BF RID: 10175
	public float Timer;
}
