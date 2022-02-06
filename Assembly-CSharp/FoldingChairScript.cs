using System;
using UnityEngine;

// Token: 0x02000514 RID: 1300
public class FoldingChairScript : MonoBehaviour
{
	// Token: 0x06002149 RID: 8521 RVA: 0x001E8D54 File Offset: 0x001E6F54
	private void Start()
	{
		int num = UnityEngine.Random.Range(0, this.Student.Length);
		UnityEngine.Object.Instantiate<GameObject>(this.Student[num], base.transform.position - new Vector3(0f, 0.4f, 0f), base.transform.rotation);
	}

	// Token: 0x0400490A RID: 18698
	public GameObject[] Student;
}
