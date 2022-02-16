using System;
using UnityEngine;

// Token: 0x02000518 RID: 1304
public class RoseSpawnerScript : MonoBehaviour
{
	// Token: 0x06002158 RID: 8536 RVA: 0x001E9342 File Offset: 0x001E7542
	private void Start()
	{
		this.SpawnRose();
	}

	// Token: 0x06002159 RID: 8537 RVA: 0x001E934A File Offset: 0x001E754A
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.1f)
		{
			this.SpawnRose();
		}
	}

	// Token: 0x0600215A RID: 8538 RVA: 0x001E9374 File Offset: 0x001E7574
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

	// Token: 0x04004916 RID: 18710
	public Transform DramaGirl;

	// Token: 0x04004917 RID: 18711
	public Transform Target;

	// Token: 0x04004918 RID: 18712
	public GameObject Rose;

	// Token: 0x04004919 RID: 18713
	public float Timer;

	// Token: 0x0400491A RID: 18714
	public float ForwardForce;

	// Token: 0x0400491B RID: 18715
	public float UpwardForce;
}
