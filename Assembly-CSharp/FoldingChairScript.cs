using System;
using UnityEngine;

// Token: 0x02000520 RID: 1312
public class FoldingChairScript : MonoBehaviour
{
	// Token: 0x06002187 RID: 8583 RVA: 0x001EDF98 File Offset: 0x001EC198
	private void Start()
	{
		int num = UnityEngine.Random.Range(0, this.Student.Length);
		UnityEngine.Object.Instantiate<GameObject>(this.Student[num], base.transform.position - new Vector3(0f, 0.4f, 0f), base.transform.rotation);
	}

	// Token: 0x040049D1 RID: 18897
	public GameObject[] Student;
}
