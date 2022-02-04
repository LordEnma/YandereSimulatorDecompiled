using System;
using UnityEngine;

// Token: 0x02000517 RID: 1303
public class RoseSpawnerScript : MonoBehaviour
{
	// Token: 0x0600214E RID: 8526 RVA: 0x001E8C8A File Offset: 0x001E6E8A
	private void Start()
	{
		this.SpawnRose();
	}

	// Token: 0x0600214F RID: 8527 RVA: 0x001E8C92 File Offset: 0x001E6E92
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.1f)
		{
			this.SpawnRose();
		}
	}

	// Token: 0x06002150 RID: 8528 RVA: 0x001E8CBC File Offset: 0x001E6EBC
	private void SpawnRose()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Rose, base.transform.position, Quaternion.identity);
		gameObject.GetComponent<Rigidbody>().AddForce(base.transform.forward * this.ForwardForce);
		gameObject.GetComponent<Rigidbody>().AddForce(base.transform.up * this.UpwardForce);
		gameObject.transform.localEulerAngles = new Vector3(UnityEngine.Random.Range(0f, 360f), UnityEngine.Random.Range(0f, 360f), UnityEngine.Random.Range(0f, 360f));
		base.transform.localPosition = new Vector3(UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.y, base.transform.localPosition.z);
		base.transform.LookAt(this.DramaGirl);
		this.Timer = 0f;
	}

	// Token: 0x0400490A RID: 18698
	public Transform DramaGirl;

	// Token: 0x0400490B RID: 18699
	public Transform Target;

	// Token: 0x0400490C RID: 18700
	public GameObject Rose;

	// Token: 0x0400490D RID: 18701
	public float Timer;

	// Token: 0x0400490E RID: 18702
	public float ForwardForce;

	// Token: 0x0400490F RID: 18703
	public float UpwardForce;
}
