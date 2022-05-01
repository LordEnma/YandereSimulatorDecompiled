using System;
using UnityEngine;

// Token: 0x02000361 RID: 865
public class MatchScript : MonoBehaviour
{
	// Token: 0x060019AD RID: 6573 RVA: 0x001066C4 File Offset: 0x001048C4
	private void Update()
	{
		base.transform.Rotate(360f * Time.deltaTime, 360f * Time.deltaTime, 360f * Time.deltaTime);
	}

	// Token: 0x060019AE RID: 6574 RVA: 0x001066F4 File Offset: 0x001048F4
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

	// Token: 0x04002936 RID: 10550
	public GameObject Distraction;

	// Token: 0x04002937 RID: 10551
	public GameObject GiggleDisc;

	// Token: 0x04002938 RID: 10552
	public GameObject GasCloud;

	// Token: 0x04002939 RID: 10553
	public GameObject Flash;

	// Token: 0x0400293A RID: 10554
	public AudioClip Bang;

	// Token: 0x0400293B RID: 10555
	public bool StinkBomb;

	// Token: 0x0400293C RID: 10556
	public bool Pebble;
}
