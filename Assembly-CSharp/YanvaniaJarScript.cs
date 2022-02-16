using System;
using UnityEngine;

// Token: 0x020004DA RID: 1242
public class YanvaniaJarScript : MonoBehaviour
{
	// Token: 0x06002094 RID: 8340 RVA: 0x001DE8B4 File Offset: 0x001DCAB4
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

	// Token: 0x04004759 RID: 18265
	public GameObject Explosion;

	// Token: 0x0400475A RID: 18266
	public bool Destroyed;

	// Token: 0x0400475B RID: 18267
	public AudioClip Break;

	// Token: 0x0400475C RID: 18268
	public GameObject Shard;
}
