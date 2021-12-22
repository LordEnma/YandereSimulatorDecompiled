using System;
using UnityEngine;

// Token: 0x020004D6 RID: 1238
public class YanvaniaJarScript : MonoBehaviour
{
	// Token: 0x06002074 RID: 8308 RVA: 0x001DB9E4 File Offset: 0x001D9BE4
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

	// Token: 0x04004718 RID: 18200
	public GameObject Explosion;

	// Token: 0x04004719 RID: 18201
	public bool Destroyed;

	// Token: 0x0400471A RID: 18202
	public AudioClip Break;

	// Token: 0x0400471B RID: 18203
	public GameObject Shard;
}
