using System;
using UnityEngine;

// Token: 0x020004F0 RID: 1264
public class YanvaniaWineScript : MonoBehaviour
{
	// Token: 0x06002108 RID: 8456 RVA: 0x001E96D4 File Offset: 0x001E78D4
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

	// Token: 0x040048C0 RID: 18624
	public GameObject Shards;

	// Token: 0x040048C1 RID: 18625
	public float Rotation;
}
