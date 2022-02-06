using System;
using UnityEngine;

// Token: 0x02000517 RID: 1303
public class RoseSpawnerScript : MonoBehaviour
{
	// Token: 0x06002151 RID: 8529 RVA: 0x001E8E8E File Offset: 0x001E708E
	private void Start()
	{
		this.SpawnRose();
	}

	// Token: 0x06002152 RID: 8530 RVA: 0x001E8E96 File Offset: 0x001E7096
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.1f)
		{
			this.SpawnRose();
		}
	}

	// Token: 0x06002153 RID: 8531 RVA: 0x001E8EC0 File Offset: 0x001E70C0
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

	// Token: 0x0400490D RID: 18701
	public Transform DramaGirl;

	// Token: 0x0400490E RID: 18702
	public Transform Target;

	// Token: 0x0400490F RID: 18703
	public GameObject Rose;

	// Token: 0x04004910 RID: 18704
	public float Timer;

	// Token: 0x04004911 RID: 18705
	public float ForwardForce;

	// Token: 0x04004912 RID: 18706
	public float UpwardForce;
}
