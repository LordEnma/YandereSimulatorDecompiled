using System;
using UnityEngine;

// Token: 0x020004E1 RID: 1249
public class YanvaniaWineScript : MonoBehaviour
{
	// Token: 0x0600209D RID: 8349 RVA: 0x001DE96C File Offset: 0x001DCB6C
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

	// Token: 0x04004783 RID: 18307
	public GameObject Shards;

	// Token: 0x04004784 RID: 18308
	public float Rotation;
}
