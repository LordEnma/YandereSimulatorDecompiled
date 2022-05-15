using System;
using UnityEngine;

// Token: 0x0200048A RID: 1162
public class TrailScript : MonoBehaviour
{
	// Token: 0x06001F2F RID: 7983 RVA: 0x001B9DEC File Offset: 0x001B7FEC
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
