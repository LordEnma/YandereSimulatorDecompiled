using System;
using UnityEngine;

// Token: 0x020004E7 RID: 1255
public class YanvaniaJarScript : MonoBehaviour
{
	// Token: 0x060020EC RID: 8428 RVA: 0x001E7174 File Offset: 0x001E5374
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

	// Token: 0x04004869 RID: 18537
	public GameObject Explosion;

	// Token: 0x0400486A RID: 18538
	public bool Destroyed;

	// Token: 0x0400486B RID: 18539
	public AudioClip Break;

	// Token: 0x0400486C RID: 18540
	public GameObject Shard;
}
