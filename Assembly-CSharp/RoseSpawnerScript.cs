using System;
using UnityEngine;

// Token: 0x02000516 RID: 1302
public class RoseSpawnerScript : MonoBehaviour
{
	// Token: 0x06002146 RID: 8518 RVA: 0x001E7402 File Offset: 0x001E5602
	private void Start()
	{
		this.SpawnRose();
	}

	// Token: 0x06002147 RID: 8519 RVA: 0x001E740A File Offset: 0x001E560A
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.1f)
		{
			this.SpawnRose();
		}
	}

	// Token: 0x06002148 RID: 8520 RVA: 0x001E7434 File Offset: 0x001E5634
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

	// Token: 0x040048F2 RID: 18674
	public Transform DramaGirl;

	// Token: 0x040048F3 RID: 18675
	public Transform Target;

	// Token: 0x040048F4 RID: 18676
	public GameObject Rose;

	// Token: 0x040048F5 RID: 18677
	public float Timer;

	// Token: 0x040048F6 RID: 18678
	public float ForwardForce;

	// Token: 0x040048F7 RID: 18679
	public float UpwardForce;
}
