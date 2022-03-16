using System;
using UnityEngine;

// Token: 0x020004E9 RID: 1257
public class YanvaniaWineScript : MonoBehaviour
{
	// Token: 0x060020D6 RID: 8406 RVA: 0x001E3DCC File Offset: 0x001E1FCC
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

	// Token: 0x04004833 RID: 18483
	public GameObject Shards;

	// Token: 0x04004834 RID: 18484
	public float Rotation;
}
