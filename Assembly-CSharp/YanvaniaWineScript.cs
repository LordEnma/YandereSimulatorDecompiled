using System;
using UnityEngine;

// Token: 0x020004E2 RID: 1250
public class YanvaniaWineScript : MonoBehaviour
{
	// Token: 0x060020A5 RID: 8357 RVA: 0x001E01F4 File Offset: 0x001DE3F4
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

	// Token: 0x0400479B RID: 18331
	public GameObject Shards;

	// Token: 0x0400479C RID: 18332
	public float Rotation;
}
