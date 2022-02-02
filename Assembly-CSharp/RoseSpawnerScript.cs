using System;
using UnityEngine;

// Token: 0x02000517 RID: 1303
public class RoseSpawnerScript : MonoBehaviour
{
	// Token: 0x0600214C RID: 8524 RVA: 0x001E8972 File Offset: 0x001E6B72
	private void Start()
	{
		this.SpawnRose();
	}

	// Token: 0x0600214D RID: 8525 RVA: 0x001E897A File Offset: 0x001E6B7A
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.1f)
		{
			this.SpawnRose();
		}
	}

	// Token: 0x0600214E RID: 8526 RVA: 0x001E89A4 File Offset: 0x001E6BA4
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

	// Token: 0x04004904 RID: 18692
	public Transform DramaGirl;

	// Token: 0x04004905 RID: 18693
	public Transform Target;

	// Token: 0x04004906 RID: 18694
	public GameObject Rose;

	// Token: 0x04004907 RID: 18695
	public float Timer;

	// Token: 0x04004908 RID: 18696
	public float ForwardForce;

	// Token: 0x04004909 RID: 18697
	public float UpwardForce;
}
