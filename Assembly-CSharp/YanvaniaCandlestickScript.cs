using System;
using UnityEngine;

// Token: 0x020004E2 RID: 1250
public class YanvaniaCandlestickScript : MonoBehaviour
{
	// Token: 0x060020DB RID: 8411 RVA: 0x001E5E0C File Offset: 0x001E400C
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

	// Token: 0x04004831 RID: 18481
	public GameObject DestroyedCandlestick;

	// Token: 0x04004832 RID: 18482
	public bool Destroyed;

	// Token: 0x04004833 RID: 18483
	public AudioClip Break;
}
