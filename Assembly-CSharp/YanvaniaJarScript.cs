using System;
using UnityEngine;

// Token: 0x020004D9 RID: 1241
public class YanvaniaJarScript : MonoBehaviour
{
	// Token: 0x06002084 RID: 8324 RVA: 0x001DD644 File Offset: 0x001DB844
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

	// Token: 0x0400473C RID: 18236
	public GameObject Explosion;

	// Token: 0x0400473D RID: 18237
	public bool Destroyed;

	// Token: 0x0400473E RID: 18238
	public AudioClip Break;

	// Token: 0x0400473F RID: 18239
	public GameObject Shard;
}
