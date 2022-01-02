using System;
using UnityEngine;

// Token: 0x020000D1 RID: 209
public class ArcScript : MonoBehaviour
{
	// Token: 0x060009D5 RID: 2517 RVA: 0x00051FA8 File Offset: 0x000501A8
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 1f)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.ArcTrail, base.transform.position, base.transform.rotation).GetComponent<Rigidbody>().AddRelativeForce(ArcScript.NEW_ARC_RELATIVE_FORCE);
			this.Timer = 0f;
		}
	}

	// Token: 0x04000A56 RID: 2646
	private static readonly Vector3 NEW_ARC_RELATIVE_FORCE = Vector3.forward * 375f;

	// Token: 0x04000A57 RID: 2647
	public GameObject ArcTrail;

	// Token: 0x04000A58 RID: 2648
	public float Timer;
}
