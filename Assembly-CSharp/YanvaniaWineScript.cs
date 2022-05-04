using System;
using UnityEngine;

// Token: 0x020004EF RID: 1263
public class YanvaniaWineScript : MonoBehaviour
{
	// Token: 0x060020FD RID: 8445 RVA: 0x001E7B1C File Offset: 0x001E5D1C
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

	// Token: 0x04004890 RID: 18576
	public GameObject Shards;

	// Token: 0x04004891 RID: 18577
	public float Rotation;
}
