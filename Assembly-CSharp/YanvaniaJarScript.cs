using System;
using UnityEngine;

// Token: 0x020004D4 RID: 1236
public class YanvaniaJarScript : MonoBehaviour
{
	// Token: 0x06002063 RID: 8291 RVA: 0x001DA2B0 File Offset: 0x001D84B0
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

	// Token: 0x040046D9 RID: 18137
	public GameObject Explosion;

	// Token: 0x040046DA RID: 18138
	public bool Destroyed;

	// Token: 0x040046DB RID: 18139
	public AudioClip Break;

	// Token: 0x040046DC RID: 18140
	public GameObject Shard;
}
