using System;
using UnityEngine;

// Token: 0x02000525 RID: 1317
public class RoseSpawnerScript : MonoBehaviour
{
	// Token: 0x060021A7 RID: 8615 RVA: 0x001F04EA File Offset: 0x001EE6EA
	private void Start()
	{
		this.SpawnRose();
	}

	// Token: 0x060021A8 RID: 8616 RVA: 0x001F04F2 File Offset: 0x001EE6F2
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.1f)
		{
			this.SpawnRose();
		}
	}

	// Token: 0x060021A9 RID: 8617 RVA: 0x001F051C File Offset: 0x001EE71C
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

	// Token: 0x04004A00 RID: 18944
	public Transform DramaGirl;

	// Token: 0x04004A01 RID: 18945
	public Transform Target;

	// Token: 0x04004A02 RID: 18946
	public GameObject Rose;

	// Token: 0x04004A03 RID: 18947
	public float Timer;

	// Token: 0x04004A04 RID: 18948
	public float ForwardForce;

	// Token: 0x04004A05 RID: 18949
	public float UpwardForce;
}
