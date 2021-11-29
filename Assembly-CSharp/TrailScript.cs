using System;
using UnityEngine;

// Token: 0x0200047B RID: 1147
public class TrailScript : MonoBehaviour
{
	// Token: 0x06001EC1 RID: 7873 RVA: 0x001AF2E8 File Offset: 0x001AD4E8
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
