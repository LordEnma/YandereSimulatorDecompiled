using System;
using UnityEngine;

// Token: 0x020004F0 RID: 1264
public class YanvaniaWineScript : MonoBehaviour
{
	// Token: 0x06002107 RID: 8455 RVA: 0x001E916C File Offset: 0x001E736C
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

	// Token: 0x040048B7 RID: 18615
	public GameObject Shards;

	// Token: 0x040048B8 RID: 18616
	public float Rotation;
}
