using System;
using UnityEngine;

// Token: 0x020004E2 RID: 1250
public class YanvaniaWineScript : MonoBehaviour
{
	// Token: 0x060020A3 RID: 8355 RVA: 0x001DFEDC File Offset: 0x001DE0DC
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

	// Token: 0x04004795 RID: 18325
	public GameObject Shards;

	// Token: 0x04004796 RID: 18326
	public float Rotation;
}
