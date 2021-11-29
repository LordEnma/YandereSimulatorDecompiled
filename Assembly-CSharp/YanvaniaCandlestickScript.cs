using System;
using UnityEngine;

// Token: 0x020004CF RID: 1231
public class YanvaniaCandlestickScript : MonoBehaviour
{
	// Token: 0x06002051 RID: 8273 RVA: 0x001D89E0 File Offset: 0x001D6BE0
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

	// Token: 0x04004698 RID: 18072
	public GameObject DestroyedCandlestick;

	// Token: 0x04004699 RID: 18073
	public bool Destroyed;

	// Token: 0x0400469A RID: 18074
	public AudioClip Break;
}
