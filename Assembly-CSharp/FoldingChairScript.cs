using System;
using UnityEngine;

// Token: 0x02000523 RID: 1315
public class FoldingChairScript : MonoBehaviour
{
	// Token: 0x060021AB RID: 8619 RVA: 0x001F2064 File Offset: 0x001F0264
	private void Start()
	{
		int num = UnityEngine.Random.Range(0, this.Student.Length);
		UnityEngine.Object.Instantiate<GameObject>(this.Student[num], base.transform.position - new Vector3(0f, 0.4f, 0f), base.transform.rotation);
	}

	// Token: 0x04004A2D RID: 18989
	public GameObject[] Student;
}
