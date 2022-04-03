using System;
using UnityEngine;

// Token: 0x02000523 RID: 1315
public class RoseSpawnerScript : MonoBehaviour
{
	// Token: 0x0600218F RID: 8591 RVA: 0x001EE0D2 File Offset: 0x001EC2D2
	private void Start()
	{
		this.SpawnRose();
	}

	// Token: 0x06002190 RID: 8592 RVA: 0x001EE0DA File Offset: 0x001EC2DA
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.1f)
		{
			this.SpawnRose();
		}
	}

	// Token: 0x06002191 RID: 8593 RVA: 0x001EE104 File Offset: 0x001EC304
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

	// Token: 0x040049D4 RID: 18900
	public Transform DramaGirl;

	// Token: 0x040049D5 RID: 18901
	public Transform Target;

	// Token: 0x040049D6 RID: 18902
	public GameObject Rose;

	// Token: 0x040049D7 RID: 18903
	public float Timer;

	// Token: 0x040049D8 RID: 18904
	public float ForwardForce;

	// Token: 0x040049D9 RID: 18905
	public float UpwardForce;
}
