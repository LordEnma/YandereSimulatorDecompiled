using System;
using UnityEngine;

// Token: 0x020004DD RID: 1245
public class YanvaniaWineScript : MonoBehaviour
{
	// Token: 0x0600207E RID: 8318 RVA: 0x001DC2A8 File Offset: 0x001DA4A8
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

	// Token: 0x04004727 RID: 18215
	public GameObject Shards;

	// Token: 0x04004728 RID: 18216
	public float Rotation;
}
