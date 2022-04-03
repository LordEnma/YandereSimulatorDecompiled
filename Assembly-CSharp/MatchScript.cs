using System;
using UnityEngine;

// Token: 0x02000360 RID: 864
public class MatchScript : MonoBehaviour
{
	// Token: 0x0600199F RID: 6559 RVA: 0x00105E30 File Offset: 0x00104030
	private void Update()
	{
		base.transform.Rotate(360f * Time.deltaTime, 360f * Time.deltaTime, 360f * Time.deltaTime);
	}

	// Token: 0x060019A0 RID: 6560 RVA: 0x00105E60 File Offset: 0x00104060
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

	// Token: 0x04002922 RID: 10530
	public GameObject Distraction;

	// Token: 0x04002923 RID: 10531
	public GameObject GiggleDisc;

	// Token: 0x04002924 RID: 10532
	public GameObject GasCloud;

	// Token: 0x04002925 RID: 10533
	public GameObject Flash;

	// Token: 0x04002926 RID: 10534
	public AudioClip Bang;

	// Token: 0x04002927 RID: 10535
	public bool StinkBomb;

	// Token: 0x04002928 RID: 10536
	public bool Pebble;
}
