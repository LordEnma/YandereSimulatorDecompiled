using System;
using UnityEngine;

// Token: 0x020004E1 RID: 1249
public class YanvaniaCandlestickScript : MonoBehaviour
{
	// Token: 0x060020CF RID: 8399 RVA: 0x001E4158 File Offset: 0x001E2358
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

	// Token: 0x04004801 RID: 18433
	public GameObject DestroyedCandlestick;

	// Token: 0x04004802 RID: 18434
	public bool Destroyed;

	// Token: 0x04004803 RID: 18435
	public AudioClip Break;
}
