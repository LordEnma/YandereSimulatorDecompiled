using System;
using UnityEngine;

// Token: 0x020003AC RID: 940
public class PoliceWalk : MonoBehaviour
{
	// Token: 0x06001ABE RID: 6846 RVA: 0x00124388 File Offset: 0x00122588
	private void Update()
	{
		Vector3 position = base.transform.position;
		position.z += Time.deltaTime;
		base.transform.position = position;
	}
}
