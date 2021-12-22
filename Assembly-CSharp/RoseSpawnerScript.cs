using System;
using UnityEngine;

// Token: 0x02000514 RID: 1300
public class RoseSpawnerScript : MonoBehaviour
{
	// Token: 0x06002138 RID: 8504 RVA: 0x001E6472 File Offset: 0x001E4672
	private void Start()
	{
		this.SpawnRose();
	}

	// Token: 0x06002139 RID: 8505 RVA: 0x001E647A File Offset: 0x001E467A
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.1f)
		{
			this.SpawnRose();
		}
	}

	// Token: 0x0600213A RID: 8506 RVA: 0x001E64A4 File Offset: 0x001E46A4
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

	// Token: 0x040048D5 RID: 18645
	public Transform DramaGirl;

	// Token: 0x040048D6 RID: 18646
	public Transform Target;

	// Token: 0x040048D7 RID: 18647
	public GameObject Rose;

	// Token: 0x040048D8 RID: 18648
	public float Timer;

	// Token: 0x040048D9 RID: 18649
	public float ForwardForce;

	// Token: 0x040048DA RID: 18650
	public float UpwardForce;
}
