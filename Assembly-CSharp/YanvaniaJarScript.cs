using System;
using UnityEngine;

// Token: 0x020004DC RID: 1244
public class YanvaniaJarScript : MonoBehaviour
{
	// Token: 0x060020A3 RID: 8355 RVA: 0x001DFE6C File Offset: 0x001DE06C
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

	// Token: 0x04004786 RID: 18310
	public GameObject Explosion;

	// Token: 0x04004787 RID: 18311
	public bool Destroyed;

	// Token: 0x04004788 RID: 18312
	public AudioClip Break;

	// Token: 0x04004789 RID: 18313
	public GameObject Shard;
}
