using System;
using UnityEngine;

// Token: 0x02000362 RID: 866
public class MatchScript : MonoBehaviour
{
	// Token: 0x060019B3 RID: 6579 RVA: 0x00106ECD File Offset: 0x001050CD
	private void Update()
	{
		base.transform.Rotate(360f * Time.deltaTime, 360f * Time.deltaTime, 360f * Time.deltaTime);
	}

	// Token: 0x060019B4 RID: 6580 RVA: 0x00106EFC File Offset: 0x001050FC
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

	// Token: 0x04002947 RID: 10567
	public GameObject Distraction;

	// Token: 0x04002948 RID: 10568
	public GameObject GiggleDisc;

	// Token: 0x04002949 RID: 10569
	public GameObject GasCloud;

	// Token: 0x0400294A RID: 10570
	public GameObject Flash;

	// Token: 0x0400294B RID: 10571
	public AudioClip Bang;

	// Token: 0x0400294C RID: 10572
	public bool StinkBomb;

	// Token: 0x0400294D RID: 10573
	public bool Pebble;
}
