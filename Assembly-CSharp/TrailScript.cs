using System;
using UnityEngine;

// Token: 0x02000481 RID: 1153
public class TrailScript : MonoBehaviour
{
	// Token: 0x06001EF0 RID: 7920 RVA: 0x001B353C File Offset: 0x001B173C
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
