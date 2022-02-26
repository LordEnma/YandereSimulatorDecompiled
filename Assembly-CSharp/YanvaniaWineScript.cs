using System;
using UnityEngine;

// Token: 0x020004E4 RID: 1252
public class YanvaniaWineScript : MonoBehaviour
{
	// Token: 0x060020B8 RID: 8376 RVA: 0x001E148C File Offset: 0x001DF68C
	private void Update()
	{
		if (base.transform.parent == null)
		{
			this.Rotation += Time.deltaTime * 360f;
			base.transform.localEulerAngles = new Vector3(this.Rotation, this.Rotation, this.Rotation);
			if (base.transform.position.y < 6.75f)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.Shards, new Vector3(base.transform.position.x, 6.75f, base.transform.position.z), Quaternion.identity).transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
				AudioSource.PlayClipAtPoint(base.GetComponent<AudioSource>().clip, base.transform.position);
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}

	// Token: 0x040047B7 RID: 18359
	public GameObject Shards;

	// Token: 0x040047B8 RID: 18360
	public float Rotation;
}
