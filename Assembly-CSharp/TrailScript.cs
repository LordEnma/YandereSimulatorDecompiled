using System;
using UnityEngine;

// Token: 0x02000487 RID: 1159
public class TrailScript : MonoBehaviour
{
	// Token: 0x06001F0F RID: 7951 RVA: 0x001B6928 File Offset: 0x001B4B28
	private void Start()
	{
		Physics.IgnoreCollision(GameObject.Find("YandereChan").GetComponent<Collider>(), base.GetComponent<Collider>());
		Physics.IgnoreLayerCollision(20, 8, false);
		Physics.IgnoreLayerCollision(8, 20, false);
		Physics.IgnoreLayerCollision(20, 15, true);
		Physics.IgnoreLayerCollision(15, 20, true);
		UnityEngine.Object.Destroy(this);
	}
}
