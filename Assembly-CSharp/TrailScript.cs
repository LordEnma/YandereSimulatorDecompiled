using System;
using UnityEngine;

// Token: 0x02000489 RID: 1161
public class TrailScript : MonoBehaviour
{
	// Token: 0x06001F27 RID: 7975 RVA: 0x001B8C74 File Offset: 0x001B6E74
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
