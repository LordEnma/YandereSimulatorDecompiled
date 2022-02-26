using System;
using UnityEngine;

// Token: 0x0200035F RID: 863
public class MatchScript : MonoBehaviour
{
	// Token: 0x06001991 RID: 6545 RVA: 0x00104AA4 File Offset: 0x00102CA4
	private void Update()
	{
		base.transform.Rotate(360f * Time.deltaTime, 360f * Time.deltaTime, 360f * Time.deltaTime);
	}

	// Token: 0x06001992 RID: 6546 RVA: 0x00104AD4 File Offset: 0x00102CD4
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == 0 || collision.gameObject.layer == 8)
		{
			if (this.StinkBomb)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.GasCloud, base.transform.position, Quaternion.identity);
			}
			else if (this.Pebble)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.Distraction, base.transform.position, Quaternion.identity);
				AudioSource.PlayClipAtPoint(this.Bang, base.transform.position);
			}
			else
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.GiggleDisc, base.transform.position, Quaternion.identity);
				gameObject.GetComponent<BoxCollider>().size = new Vector3(0.02f, 1f, 0.02f);
				gameObject.GetComponent<GiggleScript>().BangSnap = true;
				AudioSource.PlayClipAtPoint(this.Bang, base.transform.position);
			}
			UnityEngine.Object.Instantiate<GameObject>(this.Flash, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040028D7 RID: 10455
	public GameObject Distraction;

	// Token: 0x040028D8 RID: 10456
	public GameObject GiggleDisc;

	// Token: 0x040028D9 RID: 10457
	public GameObject GasCloud;

	// Token: 0x040028DA RID: 10458
	public GameObject Flash;

	// Token: 0x040028DB RID: 10459
	public AudioClip Bang;

	// Token: 0x040028DC RID: 10460
	public bool StinkBomb;

	// Token: 0x040028DD RID: 10461
	public bool Pebble;
}
