using System;
using UnityEngine;

// Token: 0x020004D8 RID: 1240
public class YanvaniaJarScript : MonoBehaviour
{
	// Token: 0x06002082 RID: 8322 RVA: 0x001DC974 File Offset: 0x001DAB74
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

	// Token: 0x04004735 RID: 18229
	public GameObject Explosion;

	// Token: 0x04004736 RID: 18230
	public bool Destroyed;

	// Token: 0x04004737 RID: 18231
	public AudioClip Break;

	// Token: 0x04004738 RID: 18232
	public GameObject Shard;
}
