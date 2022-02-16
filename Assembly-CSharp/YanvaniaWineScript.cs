using System;
using UnityEngine;

// Token: 0x020004E3 RID: 1251
public class YanvaniaWineScript : MonoBehaviour
{
	// Token: 0x060020AF RID: 8367 RVA: 0x001E08AC File Offset: 0x001DEAAC
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

	// Token: 0x040047A7 RID: 18343
	public GameObject Shards;

	// Token: 0x040047A8 RID: 18344
	public float Rotation;
}
