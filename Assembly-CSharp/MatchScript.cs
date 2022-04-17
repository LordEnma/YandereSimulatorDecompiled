using System;
using UnityEngine;

// Token: 0x02000361 RID: 865
public class MatchScript : MonoBehaviour
{
	// Token: 0x060019A9 RID: 6569 RVA: 0x001061C4 File Offset: 0x001043C4
	private void Update()
	{
		base.transform.Rotate(360f * Time.deltaTime, 360f * Time.deltaTime, 360f * Time.deltaTime);
	}

	// Token: 0x060019AA RID: 6570 RVA: 0x001061F4 File Offset: 0x001043F4
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

	// Token: 0x0400292D RID: 10541
	public GameObject Distraction;

	// Token: 0x0400292E RID: 10542
	public GameObject GiggleDisc;

	// Token: 0x0400292F RID: 10543
	public GameObject GasCloud;

	// Token: 0x04002930 RID: 10544
	public GameObject Flash;

	// Token: 0x04002931 RID: 10545
	public AudioClip Bang;

	// Token: 0x04002932 RID: 10546
	public bool StinkBomb;

	// Token: 0x04002933 RID: 10547
	public bool Pebble;
}
