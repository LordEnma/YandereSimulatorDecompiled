using System;
using UnityEngine;

// Token: 0x0200035D RID: 861
public class MatchScript : MonoBehaviour
{
	// Token: 0x0600197F RID: 6527 RVA: 0x00103E08 File Offset: 0x00102008
	private void Update()
	{
		base.transform.Rotate(360f * Time.deltaTime, 360f * Time.deltaTime, 360f * Time.deltaTime);
	}

	// Token: 0x06001980 RID: 6528 RVA: 0x00103E38 File Offset: 0x00102038
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

	// Token: 0x040028BE RID: 10430
	public GameObject Distraction;

	// Token: 0x040028BF RID: 10431
	public GameObject GiggleDisc;

	// Token: 0x040028C0 RID: 10432
	public GameObject GasCloud;

	// Token: 0x040028C1 RID: 10433
	public GameObject Flash;

	// Token: 0x040028C2 RID: 10434
	public AudioClip Bang;

	// Token: 0x040028C3 RID: 10435
	public bool StinkBomb;

	// Token: 0x040028C4 RID: 10436
	public bool Pebble;
}
