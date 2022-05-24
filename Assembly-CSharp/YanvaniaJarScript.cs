using System;
using UnityEngine;

// Token: 0x020004E7 RID: 1255
public class YanvaniaJarScript : MonoBehaviour
{
	// Token: 0x060020ED RID: 8429 RVA: 0x001E76DC File Offset: 0x001E58DC
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

	// Token: 0x04004872 RID: 18546
	public GameObject Explosion;

	// Token: 0x04004873 RID: 18547
	public bool Destroyed;

	// Token: 0x04004874 RID: 18548
	public AudioClip Break;

	// Token: 0x04004875 RID: 18549
	public GameObject Shard;
}
