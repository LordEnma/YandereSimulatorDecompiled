using System;
using UnityEngine;

// Token: 0x02000526 RID: 1318
public class RoseSpawnerScript : MonoBehaviour
{
	// Token: 0x060021B2 RID: 8626 RVA: 0x001F1C36 File Offset: 0x001EFE36
	private void Start()
	{
		this.SpawnRose();
	}

	// Token: 0x060021B3 RID: 8627 RVA: 0x001F1C3E File Offset: 0x001EFE3E
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.1f)
		{
			this.SpawnRose();
		}
	}

	// Token: 0x060021B4 RID: 8628 RVA: 0x001F1C68 File Offset: 0x001EFE68
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

	// Token: 0x04004A27 RID: 18983
	public Transform DramaGirl;

	// Token: 0x04004A28 RID: 18984
	public Transform Target;

	// Token: 0x04004A29 RID: 18985
	public GameObject Rose;

	// Token: 0x04004A2A RID: 18986
	public float Timer;

	// Token: 0x04004A2B RID: 18987
	public float ForwardForce;

	// Token: 0x04004A2C RID: 18988
	public float UpwardForce;
}
