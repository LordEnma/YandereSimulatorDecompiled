using System;
using UnityEngine;

// Token: 0x02000484 RID: 1156
public class TrailScript : MonoBehaviour
{
	// Token: 0x06001F05 RID: 7941 RVA: 0x001B53B4 File Offset: 0x001B35B4
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
