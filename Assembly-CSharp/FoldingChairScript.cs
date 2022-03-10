using System;
using UnityEngine;

// Token: 0x02000517 RID: 1303
public class FoldingChairScript : MonoBehaviour
{
	// Token: 0x0600215F RID: 8543 RVA: 0x001EA7C0 File Offset: 0x001E89C0
	private void Start()
	{
		int num = UnityEngine.Random.Range(0, this.Student.Length);
		UnityEngine.Object.Instantiate<GameObject>(this.Student[num], base.transform.position - new Vector3(0f, 0.4f, 0f), base.transform.rotation);
	}

	// Token: 0x04004940 RID: 18752
	public GameObject[] Student;
}
