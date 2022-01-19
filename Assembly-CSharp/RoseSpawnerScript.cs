using System;
using UnityEngine;

// Token: 0x02000517 RID: 1303
public class RoseSpawnerScript : MonoBehaviour
{
	// Token: 0x06002148 RID: 8520 RVA: 0x001E80D2 File Offset: 0x001E62D2
	private void Start()
	{
		this.SpawnRose();
	}

	// Token: 0x06002149 RID: 8521 RVA: 0x001E80DA File Offset: 0x001E62DA
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.1f)
		{
			this.SpawnRose();
		}
	}

	// Token: 0x0600214A RID: 8522 RVA: 0x001E8104 File Offset: 0x001E6304
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

	// Token: 0x040048F9 RID: 18681
	public Transform DramaGirl;

	// Token: 0x040048FA RID: 18682
	public Transform Target;

	// Token: 0x040048FB RID: 18683
	public GameObject Rose;

	// Token: 0x040048FC RID: 18684
	public float Timer;

	// Token: 0x040048FD RID: 18685
	public float ForwardForce;

	// Token: 0x040048FE RID: 18686
	public float UpwardForce;
}
