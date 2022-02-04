using System;
using UnityEngine;

// Token: 0x0200047F RID: 1151
public class TrailScript : MonoBehaviour
{
	// Token: 0x06001EDD RID: 7901 RVA: 0x001B23A0 File Offset: 0x001B05A0
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
