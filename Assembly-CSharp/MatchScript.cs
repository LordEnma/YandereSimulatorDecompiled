using System;
using UnityEngine;

// Token: 0x0200035B RID: 859
public class MatchScript : MonoBehaviour
{
	// Token: 0x06001971 RID: 6513 RVA: 0x001029EC File Offset: 0x00100BEC
	private void Update()
	{
		base.transform.Rotate(360f * Time.deltaTime, 360f * Time.deltaTime, 360f * Time.deltaTime);
	}

	// Token: 0x06001972 RID: 6514 RVA: 0x00102A1C File Offset: 0x00100C1C
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == 0 || collision.gameObject.layer == 8)
		{
			if (this.StinkBomb)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.GasCloud, base.transform.position, Quaternion.identity);
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

	// Token: 0x04002888 RID: 10376
	public GameObject GiggleDisc;

	// Token: 0x04002889 RID: 10377
	public GameObject GasCloud;

	// Token: 0x0400288A RID: 10378
	public GameObject Flash;

	// Token: 0x0400288B RID: 10379
	public AudioClip Bang;

	// Token: 0x0400288C RID: 10380
	public bool StinkBomb;
}
