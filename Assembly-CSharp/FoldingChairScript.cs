using System;
using UnityEngine;

// Token: 0x02000513 RID: 1299
public class FoldingChairScript : MonoBehaviour
{
	// Token: 0x0600213E RID: 8510 RVA: 0x001E72C8 File Offset: 0x001E54C8
	private void Start()
	{
		int num = UnityEngine.Random.Range(0, this.Student.Length);
		UnityEngine.Object.Instantiate<GameObject>(this.Student[num], base.transform.position - new Vector3(0f, 0.4f, 0f), base.transform.rotation);
	}

	// Token: 0x040048EF RID: 18671
	public GameObject[] Student;
}
