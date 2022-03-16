using System;
using UnityEngine;

// Token: 0x0200035F RID: 863
public class MatchScript : MonoBehaviour
{
	// Token: 0x06001999 RID: 6553 RVA: 0x00105784 File Offset: 0x00103984
	private void Update()
	{
		base.transform.Rotate(360f * Time.deltaTime, 360f * Time.deltaTime, 360f * Time.deltaTime);
	}

	// Token: 0x0600199A RID: 6554 RVA: 0x001057B4 File Offset: 0x001039B4
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

	// Token: 0x0400290F RID: 10511
	public GameObject Distraction;

	// Token: 0x04002910 RID: 10512
	public GameObject GiggleDisc;

	// Token: 0x04002911 RID: 10513
	public GameObject GasCloud;

	// Token: 0x04002912 RID: 10514
	public GameObject Flash;

	// Token: 0x04002913 RID: 10515
	public AudioClip Bang;

	// Token: 0x04002914 RID: 10516
	public bool StinkBomb;

	// Token: 0x04002915 RID: 10517
	public bool Pebble;
}
