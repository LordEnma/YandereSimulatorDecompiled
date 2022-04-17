using System;
using UnityEngine;

// Token: 0x020004E5 RID: 1253
public class YanvaniaJarScript : MonoBehaviour
{
	// Token: 0x060020D8 RID: 8408 RVA: 0x001E459C File Offset: 0x001E279C
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

	// Token: 0x0400482C RID: 18476
	public GameObject Explosion;

	// Token: 0x0400482D RID: 18477
	public bool Destroyed;

	// Token: 0x0400482E RID: 18478
	public AudioClip Break;

	// Token: 0x0400482F RID: 18479
	public GameObject Shard;
}
