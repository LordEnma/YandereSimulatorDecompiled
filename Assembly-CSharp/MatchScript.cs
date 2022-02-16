using System;
using UnityEngine;

// Token: 0x0200035E RID: 862
public class MatchScript : MonoBehaviour
{
	// Token: 0x06001988 RID: 6536 RVA: 0x00104174 File Offset: 0x00102374
	private void Update()
	{
		base.transform.Rotate(360f * Time.deltaTime, 360f * Time.deltaTime, 360f * Time.deltaTime);
	}

	// Token: 0x06001989 RID: 6537 RVA: 0x001041A4 File Offset: 0x001023A4
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

	// Token: 0x040028C8 RID: 10440
	public GameObject Distraction;

	// Token: 0x040028C9 RID: 10441
	public GameObject GiggleDisc;

	// Token: 0x040028CA RID: 10442
	public GameObject GasCloud;

	// Token: 0x040028CB RID: 10443
	public GameObject Flash;

	// Token: 0x040028CC RID: 10444
	public AudioClip Bang;

	// Token: 0x040028CD RID: 10445
	public bool StinkBomb;

	// Token: 0x040028CE RID: 10446
	public bool Pebble;
}
