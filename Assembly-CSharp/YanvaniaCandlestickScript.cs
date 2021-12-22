using System;
using UnityEngine;

// Token: 0x020004D1 RID: 1233
public class YanvaniaCandlestickScript : MonoBehaviour
{
	// Token: 0x06002062 RID: 8290 RVA: 0x001DA114 File Offset: 0x001D8314
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 19 && !this.Destroyed)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.DestroyedCandlestick, base.transform.position, Quaternion.identity).transform.localScale = base.transform.localScale;
			this.Destroyed = true;
			AudioClipPlayer.Play2D(this.Break, base.transform.position);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040046D7 RID: 18135
	public GameObject DestroyedCandlestick;

	// Token: 0x040046D8 RID: 18136
	public bool Destroyed;

	// Token: 0x040046D9 RID: 18137
	public AudioClip Break;
}
