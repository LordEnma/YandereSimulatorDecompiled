using System;
using UnityEngine;

// Token: 0x020004E0 RID: 1248
public class YanvaniaCandlestickScript : MonoBehaviour
{
	// Token: 0x060020C6 RID: 8390 RVA: 0x001E2CCC File Offset: 0x001E0ECC
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

	// Token: 0x040047EB RID: 18411
	public GameObject DestroyedCandlestick;

	// Token: 0x040047EC RID: 18412
	public bool Destroyed;

	// Token: 0x040047ED RID: 18413
	public AudioClip Break;
}
