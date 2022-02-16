using System;
using UnityEngine;

// Token: 0x02000480 RID: 1152
public class TrailScript : MonoBehaviour
{
	// Token: 0x06001EE7 RID: 7911 RVA: 0x001B29F0 File Offset: 0x001B0BF0
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
