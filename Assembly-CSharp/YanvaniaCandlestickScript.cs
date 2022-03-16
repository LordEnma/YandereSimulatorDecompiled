using System;
using UnityEngine;

// Token: 0x020004DB RID: 1243
public class YanvaniaCandlestickScript : MonoBehaviour
{
	// Token: 0x060020A9 RID: 8361 RVA: 0x001E0504 File Offset: 0x001DE704
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

	// Token: 0x040047A4 RID: 18340
	public GameObject DestroyedCandlestick;

	// Token: 0x040047A5 RID: 18341
	public bool Destroyed;

	// Token: 0x040047A6 RID: 18342
	public AudioClip Break;
}
