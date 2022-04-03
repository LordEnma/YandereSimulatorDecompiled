using System;
using UnityEngine;

// Token: 0x020004DF RID: 1247
public class YanvaniaCandlestickScript : MonoBehaviour
{
	// Token: 0x060020B7 RID: 8375 RVA: 0x001E1D40 File Offset: 0x001DFF40
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

	// Token: 0x040047D5 RID: 18389
	public GameObject DestroyedCandlestick;

	// Token: 0x040047D6 RID: 18390
	public bool Destroyed;

	// Token: 0x040047D7 RID: 18391
	public AudioClip Break;
}
