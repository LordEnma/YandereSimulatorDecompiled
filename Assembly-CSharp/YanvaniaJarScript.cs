using System;
using UnityEngine;

// Token: 0x020004D9 RID: 1241
public class YanvaniaJarScript : MonoBehaviour
{
	// Token: 0x0600208D RID: 8333 RVA: 0x001DE400 File Offset: 0x001DC600
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

	// Token: 0x04004750 RID: 18256
	public GameObject Explosion;

	// Token: 0x04004751 RID: 18257
	public bool Destroyed;

	// Token: 0x04004752 RID: 18258
	public AudioClip Break;

	// Token: 0x04004753 RID: 18259
	public GameObject Shard;
}
