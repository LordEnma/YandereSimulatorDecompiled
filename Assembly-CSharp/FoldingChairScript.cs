using System;
using UnityEngine;

// Token: 0x02000511 RID: 1297
public class FoldingChairScript : MonoBehaviour
{
	// Token: 0x06002130 RID: 8496 RVA: 0x001E6338 File Offset: 0x001E4538
	private void Start()
	{
		int num = UnityEngine.Random.Range(0, this.Student.Length);
		UnityEngine.Object.Instantiate<GameObject>(this.Student[num], base.transform.position - new Vector3(0f, 0.4f, 0f), base.transform.rotation);
	}

	// Token: 0x040048D2 RID: 18642
	public GameObject[] Student;
}
