using System;
using UnityEngine;

// Token: 0x0200051E RID: 1310
public class RoseSpawnerScript : MonoBehaviour
{
	// Token: 0x0600217F RID: 8575 RVA: 0x001EC862 File Offset: 0x001EAA62
	private void Start()
	{
		this.SpawnRose();
	}

	// Token: 0x06002180 RID: 8576 RVA: 0x001EC86A File Offset: 0x001EAA6A
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.1f)
		{
			this.SpawnRose();
		}
	}

	// Token: 0x06002181 RID: 8577 RVA: 0x001EC894 File Offset: 0x001EAA94
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

	// Token: 0x040049A2 RID: 18850
	public Transform DramaGirl;

	// Token: 0x040049A3 RID: 18851
	public Transform Target;

	// Token: 0x040049A4 RID: 18852
	public GameObject Rose;

	// Token: 0x040049A5 RID: 18853
	public float Timer;

	// Token: 0x040049A6 RID: 18854
	public float ForwardForce;

	// Token: 0x040049A7 RID: 18855
	public float UpwardForce;
}
