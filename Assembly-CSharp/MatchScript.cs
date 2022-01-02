using System;
using UnityEngine;

// Token: 0x0200035C RID: 860
public class MatchScript : MonoBehaviour
{
	// Token: 0x0600197A RID: 6522 RVA: 0x00103508 File Offset: 0x00101708
	private void Update()
	{
		base.transform.Rotate(360f * Time.deltaTime, 360f * Time.deltaTime, 360f * Time.deltaTime);
	}

	// Token: 0x0600197B RID: 6523 RVA: 0x00103538 File Offset: 0x00101738
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

	// Token: 0x040028B1 RID: 10417
	public GameObject GiggleDisc;

	// Token: 0x040028B2 RID: 10418
	public GameObject GasCloud;

	// Token: 0x040028B3 RID: 10419
	public GameObject Flash;

	// Token: 0x040028B4 RID: 10420
	public AudioClip Bang;

	// Token: 0x040028B5 RID: 10421
	public bool StinkBomb;
}
