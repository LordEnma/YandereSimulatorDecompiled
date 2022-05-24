using System;
using UnityEngine;

// Token: 0x02000362 RID: 866
public class MatchScript : MonoBehaviour
{
	// Token: 0x060019B4 RID: 6580 RVA: 0x001070D1 File Offset: 0x001052D1
	private void Update()
	{
		base.transform.Rotate(360f * Time.deltaTime, 360f * Time.deltaTime, 360f * Time.deltaTime);
	}

	// Token: 0x060019B5 RID: 6581 RVA: 0x00107100 File Offset: 0x00105300
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

	// Token: 0x0400294E RID: 10574
	public GameObject Distraction;

	// Token: 0x0400294F RID: 10575
	public GameObject GiggleDisc;

	// Token: 0x04002950 RID: 10576
	public GameObject GasCloud;

	// Token: 0x04002951 RID: 10577
	public GameObject Flash;

	// Token: 0x04002952 RID: 10578
	public AudioClip Bang;

	// Token: 0x04002953 RID: 10579
	public bool StinkBomb;

	// Token: 0x04002954 RID: 10580
	public bool Pebble;
}
