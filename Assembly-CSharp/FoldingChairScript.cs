using System;
using UnityEngine;

// Token: 0x02000516 RID: 1302
public class FoldingChairScript : MonoBehaviour
{
	// Token: 0x06002159 RID: 8537 RVA: 0x001E9DE8 File Offset: 0x001E7FE8
	private void Start()
	{
		int num = UnityEngine.Random.Range(0, this.Student.Length);
		UnityEngine.Object.Instantiate<GameObject>(this.Student[num], base.transform.position - new Vector3(0f, 0.4f, 0f), base.transform.rotation);
	}

	// Token: 0x04004923 RID: 18723
	public GameObject[] Student;
}
