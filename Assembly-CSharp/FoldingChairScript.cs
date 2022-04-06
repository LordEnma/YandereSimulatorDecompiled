using System;
using UnityEngine;

// Token: 0x02000521 RID: 1313
public class FoldingChairScript : MonoBehaviour
{
	// Token: 0x0600218F RID: 8591 RVA: 0x001EE4C8 File Offset: 0x001EC6C8
	private void Start()
	{
		int num = UnityEngine.Random.Range(0, this.Student.Length);
		UnityEngine.Object.Instantiate<GameObject>(this.Student[num], base.transform.position - new Vector3(0f, 0.4f, 0f), base.transform.rotation);
	}

	// Token: 0x040049D5 RID: 18901
	public GameObject[] Student;
}
