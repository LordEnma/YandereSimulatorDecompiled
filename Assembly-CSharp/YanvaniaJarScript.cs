using System;
using UnityEngine;

// Token: 0x020004E6 RID: 1254
public class YanvaniaJarScript : MonoBehaviour
{
	// Token: 0x060020E2 RID: 8418 RVA: 0x001E5B24 File Offset: 0x001E3D24
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

	// Token: 0x04004842 RID: 18498
	public GameObject Explosion;

	// Token: 0x04004843 RID: 18499
	public bool Destroyed;

	// Token: 0x04004844 RID: 18500
	public AudioClip Break;

	// Token: 0x04004845 RID: 18501
	public GameObject Shard;
}
