using System;
using UnityEngine;

// Token: 0x02000524 RID: 1316
public class RoseSpawnerScript : MonoBehaviour
{
	// Token: 0x0600219E RID: 8606 RVA: 0x001EF05E File Offset: 0x001ED25E
	private void Start()
	{
		this.SpawnRose();
	}

	// Token: 0x0600219F RID: 8607 RVA: 0x001EF066 File Offset: 0x001ED266
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.1f)
		{
			this.SpawnRose();
		}
	}

	// Token: 0x060021A0 RID: 8608 RVA: 0x001EF090 File Offset: 0x001ED290
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

	// Token: 0x040049EA RID: 18922
	public Transform DramaGirl;

	// Token: 0x040049EB RID: 18923
	public Transform Target;

	// Token: 0x040049EC RID: 18924
	public GameObject Rose;

	// Token: 0x040049ED RID: 18925
	public float Timer;

	// Token: 0x040049EE RID: 18926
	public float ForwardForce;

	// Token: 0x040049EF RID: 18927
	public float UpwardForce;
}
