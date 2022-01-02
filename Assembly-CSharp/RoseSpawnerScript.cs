using System;
using UnityEngine;

// Token: 0x02000514 RID: 1300
public class RoseSpawnerScript : MonoBehaviour
{
	// Token: 0x0600213B RID: 8507 RVA: 0x001E6A62 File Offset: 0x001E4C62
	private void Start()
	{
		this.SpawnRose();
	}

	// Token: 0x0600213C RID: 8508 RVA: 0x001E6A6A File Offset: 0x001E4C6A
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.1f)
		{
			this.SpawnRose();
		}
	}

	// Token: 0x0600213D RID: 8509 RVA: 0x001E6A94 File Offset: 0x001E4C94
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

	// Token: 0x040048DE RID: 18654
	public Transform DramaGirl;

	// Token: 0x040048DF RID: 18655
	public Transform Target;

	// Token: 0x040048E0 RID: 18656
	public GameObject Rose;

	// Token: 0x040048E1 RID: 18657
	public float Timer;

	// Token: 0x040048E2 RID: 18658
	public float ForwardForce;

	// Token: 0x040048E3 RID: 18659
	public float UpwardForce;
}
