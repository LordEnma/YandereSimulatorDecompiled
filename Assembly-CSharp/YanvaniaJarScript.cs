using System;
using UnityEngine;

// Token: 0x020004E0 RID: 1248
public class YanvaniaJarScript : MonoBehaviour
{
	// Token: 0x060020BB RID: 8379 RVA: 0x001E1DD4 File Offset: 0x001DFFD4
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

	// Token: 0x040047E5 RID: 18405
	public GameObject Explosion;

	// Token: 0x040047E6 RID: 18406
	public bool Destroyed;

	// Token: 0x040047E7 RID: 18407
	public AudioClip Break;

	// Token: 0x040047E8 RID: 18408
	public GameObject Shard;
}
