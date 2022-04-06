using System;
using UnityEngine;

// Token: 0x02000524 RID: 1316
public class RoseSpawnerScript : MonoBehaviour
{
	// Token: 0x06002197 RID: 8599 RVA: 0x001EE602 File Offset: 0x001EC802
	private void Start()
	{
		this.SpawnRose();
	}

	// Token: 0x06002198 RID: 8600 RVA: 0x001EE60A File Offset: 0x001EC80A
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.1f)
		{
			this.SpawnRose();
		}
	}

	// Token: 0x06002199 RID: 8601 RVA: 0x001EE634 File Offset: 0x001EC834
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

	// Token: 0x040049D8 RID: 18904
	public Transform DramaGirl;

	// Token: 0x040049D9 RID: 18905
	public Transform Target;

	// Token: 0x040049DA RID: 18906
	public GameObject Rose;

	// Token: 0x040049DB RID: 18907
	public float Timer;

	// Token: 0x040049DC RID: 18908
	public float ForwardForce;

	// Token: 0x040049DD RID: 18909
	public float UpwardForce;
}
