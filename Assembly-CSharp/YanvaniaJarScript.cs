using System;
using UnityEngine;

// Token: 0x020004DB RID: 1243
public class YanvaniaJarScript : MonoBehaviour
{
	// Token: 0x0600209D RID: 8349 RVA: 0x001DF494 File Offset: 0x001DD694
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

	// Token: 0x04004769 RID: 18281
	public GameObject Explosion;

	// Token: 0x0400476A RID: 18282
	public bool Destroyed;

	// Token: 0x0400476B RID: 18283
	public AudioClip Break;

	// Token: 0x0400476C RID: 18284
	public GameObject Shard;
}
