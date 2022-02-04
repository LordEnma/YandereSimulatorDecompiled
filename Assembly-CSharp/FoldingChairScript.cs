using System;
using UnityEngine;

// Token: 0x02000514 RID: 1300
public class FoldingChairScript : MonoBehaviour
{
	// Token: 0x06002146 RID: 8518 RVA: 0x001E8B50 File Offset: 0x001E6D50
	private void Start()
	{
		int num = UnityEngine.Random.Range(0, this.Student.Length);
		UnityEngine.Object.Instantiate<GameObject>(this.Student[num], base.transform.position - new Vector3(0f, 0.4f, 0f), base.transform.rotation);
	}

	// Token: 0x04004907 RID: 18695
	public GameObject[] Student;
}
