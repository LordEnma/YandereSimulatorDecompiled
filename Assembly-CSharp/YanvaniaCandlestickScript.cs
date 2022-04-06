using System;
using UnityEngine;

// Token: 0x020004E0 RID: 1248
public class YanvaniaCandlestickScript : MonoBehaviour
{
	// Token: 0x060020BF RID: 8383 RVA: 0x001E2270 File Offset: 0x001E0470
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

	// Token: 0x040047D9 RID: 18393
	public GameObject DestroyedCandlestick;

	// Token: 0x040047DA RID: 18394
	public bool Destroyed;

	// Token: 0x040047DB RID: 18395
	public AudioClip Break;
}
