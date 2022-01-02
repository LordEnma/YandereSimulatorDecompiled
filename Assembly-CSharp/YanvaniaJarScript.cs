using System;
using UnityEngine;

// Token: 0x020004D6 RID: 1238
public class YanvaniaJarScript : MonoBehaviour
{
	// Token: 0x06002077 RID: 8311 RVA: 0x001DBFD4 File Offset: 0x001DA1D4
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 19 && !this.Destroyed)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position + Vector3.up * 0.5f, Quaternion.identity);
			this.Destroyed = true;
			AudioClipPlayer.Play2D(this.Break, base.transform.position);
			for (int i = 1; i < 11; i++)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.Shard, base.transform.position + Vector3.up * UnityEngine.Random.Range(0f, 1f) + Vector3.right * UnityEngine.Random.Range(-0.5f, 0.5f), Quaternion.identity);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004721 RID: 18209
	public GameObject Explosion;

	// Token: 0x04004722 RID: 18210
	public bool Destroyed;

	// Token: 0x04004723 RID: 18211
	public AudioClip Break;

	// Token: 0x04004724 RID: 18212
	public GameObject Shard;
}
