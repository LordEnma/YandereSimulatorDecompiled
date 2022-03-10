using System;
using UnityEngine;

// Token: 0x0200051A RID: 1306
public class RoseSpawnerScript : MonoBehaviour
{
	// Token: 0x06002167 RID: 8551 RVA: 0x001EA8FA File Offset: 0x001E8AFA
	private void Start()
	{
		this.SpawnRose();
	}

	// Token: 0x06002168 RID: 8552 RVA: 0x001EA902 File Offset: 0x001E8B02
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.1f)
		{
			this.SpawnRose();
		}
	}

	// Token: 0x06002169 RID: 8553 RVA: 0x001EA92C File Offset: 0x001E8B2C
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

	// Token: 0x04004943 RID: 18755
	public Transform DramaGirl;

	// Token: 0x04004944 RID: 18756
	public Transform Target;

	// Token: 0x04004945 RID: 18757
	public GameObject Rose;

	// Token: 0x04004946 RID: 18758
	public float Timer;

	// Token: 0x04004947 RID: 18759
	public float ForwardForce;

	// Token: 0x04004948 RID: 18760
	public float UpwardForce;
}
