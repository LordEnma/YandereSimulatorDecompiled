using System;
using UnityEngine;

// Token: 0x02000512 RID: 1298
public class RoseSpawnerScript : MonoBehaviour
{
	// Token: 0x06002127 RID: 8487 RVA: 0x001E4D3E File Offset: 0x001E2F3E
	private void Start()
	{
		this.SpawnRose();
	}

	// Token: 0x06002128 RID: 8488 RVA: 0x001E4D46 File Offset: 0x001E2F46
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.1f)
		{
			this.SpawnRose();
		}
	}

	// Token: 0x06002129 RID: 8489 RVA: 0x001E4D70 File Offset: 0x001E2F70
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

	// Token: 0x04004896 RID: 18582
	public Transform DramaGirl;

	// Token: 0x04004897 RID: 18583
	public Transform Target;

	// Token: 0x04004898 RID: 18584
	public GameObject Rose;

	// Token: 0x04004899 RID: 18585
	public float Timer;

	// Token: 0x0400489A RID: 18586
	public float ForwardForce;

	// Token: 0x0400489B RID: 18587
	public float UpwardForce;
}
