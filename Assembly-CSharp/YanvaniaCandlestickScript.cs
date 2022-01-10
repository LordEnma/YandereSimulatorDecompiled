using System;
using UnityEngine;

// Token: 0x020004D3 RID: 1235
public class YanvaniaCandlestickScript : MonoBehaviour
{
	// Token: 0x06002070 RID: 8304 RVA: 0x001DB0A4 File Offset: 0x001D92A4
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

	// Token: 0x040046F4 RID: 18164
	public GameObject DestroyedCandlestick;

	// Token: 0x040046F5 RID: 18165
	public bool Destroyed;

	// Token: 0x040046F6 RID: 18166
	public AudioClip Break;
}
