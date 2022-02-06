using System;
using UnityEngine;

// Token: 0x020004E2 RID: 1250
public class YanvaniaWineScript : MonoBehaviour
{
	// Token: 0x060020A8 RID: 8360 RVA: 0x001E03F8 File Offset: 0x001DE5F8
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

	// Token: 0x0400479E RID: 18334
	public GameObject Shards;

	// Token: 0x0400479F RID: 18335
	public float Rotation;
}
