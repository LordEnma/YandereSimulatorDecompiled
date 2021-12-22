using System;
using UnityEngine;

// Token: 0x0200035C RID: 860
public class MatchScript : MonoBehaviour
{
	// Token: 0x06001978 RID: 6520 RVA: 0x00103248 File Offset: 0x00101448
	private void Update()
	{
		base.transform.Rotate(360f * Time.deltaTime, 360f * Time.deltaTime, 360f * Time.deltaTime);
	}

	// Token: 0x06001979 RID: 6521 RVA: 0x00103278 File Offset: 0x00101478
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

	// Token: 0x040028AD RID: 10413
	public GameObject GiggleDisc;

	// Token: 0x040028AE RID: 10414
	public GameObject GasCloud;

	// Token: 0x040028AF RID: 10415
	public GameObject Flash;

	// Token: 0x040028B0 RID: 10416
	public AudioClip Bang;

	// Token: 0x040028B1 RID: 10417
	public bool StinkBomb;
}
