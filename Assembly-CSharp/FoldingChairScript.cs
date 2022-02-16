using System;
using UnityEngine;

// Token: 0x02000515 RID: 1301
public class FoldingChairScript : MonoBehaviour
{
	// Token: 0x06002150 RID: 8528 RVA: 0x001E9208 File Offset: 0x001E7408
	private void Start()
	{
		int num = UnityEngine.Random.Range(0, this.Student.Length);
		UnityEngine.Object.Instantiate<GameObject>(this.Student[num], base.transform.position - new Vector3(0f, 0.4f, 0f), base.transform.rotation);
	}

	// Token: 0x04004913 RID: 18707
	public GameObject[] Student;
}
