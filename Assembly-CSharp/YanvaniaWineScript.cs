using System;
using UnityEngine;

// Token: 0x020004EE RID: 1262
public class YanvaniaWineScript : MonoBehaviour
{
	// Token: 0x060020EC RID: 8428 RVA: 0x001E5B38 File Offset: 0x001E3D38
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

	// Token: 0x04004868 RID: 18536
	public GameObject Shards;

	// Token: 0x04004869 RID: 18537
	public float Rotation;
}
