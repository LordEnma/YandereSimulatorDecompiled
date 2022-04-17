using System;
using UnityEngine;

// Token: 0x020004EE RID: 1262
public class YanvaniaWineScript : MonoBehaviour
{
	// Token: 0x060020F3 RID: 8435 RVA: 0x001E6594 File Offset: 0x001E4794
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

	// Token: 0x0400487A RID: 18554
	public GameObject Shards;

	// Token: 0x0400487B RID: 18555
	public float Rotation;
}
