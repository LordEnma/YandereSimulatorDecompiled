using System;
using UnityEngine;

// Token: 0x020004D4 RID: 1236
public class YanvaniaCandlestickScript : MonoBehaviour
{
	// Token: 0x0600207B RID: 8315 RVA: 0x001DCB30 File Offset: 0x001DAD30
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

	// Token: 0x0400470F RID: 18191
	public GameObject DestroyedCandlestick;

	// Token: 0x04004710 RID: 18192
	public bool Destroyed;

	// Token: 0x04004711 RID: 18193
	public AudioClip Break;
}
