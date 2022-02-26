using System;
using UnityEngine;

// Token: 0x020004D6 RID: 1238
public class YanvaniaCandlestickScript : MonoBehaviour
{
	// Token: 0x0600208B RID: 8331 RVA: 0x001DDBC4 File Offset: 0x001DBDC4
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

	// Token: 0x04004728 RID: 18216
	public GameObject DestroyedCandlestick;

	// Token: 0x04004729 RID: 18217
	public bool Destroyed;

	// Token: 0x0400472A RID: 18218
	public AudioClip Break;
}
