using System;
using UnityEngine;

// Token: 0x02000526 RID: 1318
public class RoseSpawnerScript : MonoBehaviour
{
	// Token: 0x060021B3 RID: 8627 RVA: 0x001F219E File Offset: 0x001F039E
	private void Start()
	{
		this.SpawnRose();
	}

	// Token: 0x060021B4 RID: 8628 RVA: 0x001F21A6 File Offset: 0x001F03A6
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.1f)
		{
			this.SpawnRose();
		}
	}

	// Token: 0x060021B5 RID: 8629 RVA: 0x001F21D0 File Offset: 0x001F03D0
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

	// Token: 0x04004A30 RID: 18992
	public Transform DramaGirl;

	// Token: 0x04004A31 RID: 18993
	public Transform Target;

	// Token: 0x04004A32 RID: 18994
	public GameObject Rose;

	// Token: 0x04004A33 RID: 18995
	public float Timer;

	// Token: 0x04004A34 RID: 18996
	public float ForwardForce;

	// Token: 0x04004A35 RID: 18997
	public float UpwardForce;
}
