using System;
using UnityEngine;

// Token: 0x020004E4 RID: 1252
public class YanvaniaJarScript : MonoBehaviour
{
	// Token: 0x060020C9 RID: 8393 RVA: 0x001E3610 File Offset: 0x001E1810
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

	// Token: 0x04004816 RID: 18454
	public GameObject Explosion;

	// Token: 0x04004817 RID: 18455
	public bool Destroyed;

	// Token: 0x04004818 RID: 18456
	public AudioClip Break;

	// Token: 0x04004819 RID: 18457
	public GameObject Shard;
}
