using System;
using UnityEngine;

// Token: 0x0200035D RID: 861
public class MatchScript : MonoBehaviour
{
	// Token: 0x0600197E RID: 6526 RVA: 0x00103868 File Offset: 0x00101A68
	private void Update()
	{
		base.transform.Rotate(360f * Time.deltaTime, 360f * Time.deltaTime, 360f * Time.deltaTime);
	}

	// Token: 0x0600197F RID: 6527 RVA: 0x00103898 File Offset: 0x00101A98
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

	// Token: 0x040028B5 RID: 10421
	public GameObject Distraction;

	// Token: 0x040028B6 RID: 10422
	public GameObject GiggleDisc;

	// Token: 0x040028B7 RID: 10423
	public GameObject GasCloud;

	// Token: 0x040028B8 RID: 10424
	public GameObject Flash;

	// Token: 0x040028B9 RID: 10425
	public AudioClip Bang;

	// Token: 0x040028BA RID: 10426
	public bool StinkBomb;

	// Token: 0x040028BB RID: 10427
	public bool Pebble;
}
