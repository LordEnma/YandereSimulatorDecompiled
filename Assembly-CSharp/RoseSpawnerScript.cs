using System;
using UnityEngine;

// Token: 0x02000519 RID: 1305
public class RoseSpawnerScript : MonoBehaviour
{
	// Token: 0x06002161 RID: 8545 RVA: 0x001E9F22 File Offset: 0x001E8122
	private void Start()
	{
		this.SpawnRose();
	}

	// Token: 0x06002162 RID: 8546 RVA: 0x001E9F2A File Offset: 0x001E812A
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.1f)
		{
			this.SpawnRose();
		}
	}

	// Token: 0x06002163 RID: 8547 RVA: 0x001E9F54 File Offset: 0x001E8154
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

	// Token: 0x04004926 RID: 18726
	public Transform DramaGirl;

	// Token: 0x04004927 RID: 18727
	public Transform Target;

	// Token: 0x04004928 RID: 18728
	public GameObject Rose;

	// Token: 0x04004929 RID: 18729
	public float Timer;

	// Token: 0x0400492A RID: 18730
	public float ForwardForce;

	// Token: 0x0400492B RID: 18731
	public float UpwardForce;
}
