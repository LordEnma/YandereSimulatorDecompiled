using System;
using UnityEngine;

// Token: 0x020000D1 RID: 209
public class ArcScript : MonoBehaviour
{
	// Token: 0x060009D5 RID: 2517 RVA: 0x00052290 File Offset: 0x00050490
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.5f)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.ArcTrail, base.transform.position, base.transform.rotation);
			gameObject.transform.parent = base.transform;
			gameObject.GetComponent<Rigidbody>().AddRelativeForce(ArcScript.NEW_ARC_RELATIVE_FORCE);
			this.Timer = 0f;
		}
	}

	// Token: 0x04000A64 RID: 2660
	private static readonly Vector3 NEW_ARC_RELATIVE_FORCE = Vector3.forward * 375f;

	// Token: 0x04000A65 RID: 2661
	public GameObject ArcTrail;

	// Token: 0x04000A66 RID: 2662
	public float Timer;
}
