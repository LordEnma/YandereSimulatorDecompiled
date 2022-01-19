using System;
using UnityEngine;

// Token: 0x02000514 RID: 1300
public class FoldingChairScript : MonoBehaviour
{
	// Token: 0x06002140 RID: 8512 RVA: 0x001E7F98 File Offset: 0x001E6198
	private void Start()
	{
		int num = UnityEngine.Random.Range(0, this.Student.Length);
		UnityEngine.Object.Instantiate<GameObject>(this.Student[num], base.transform.position - new Vector3(0f, 0.4f, 0f), base.transform.rotation);
	}

	// Token: 0x040048F6 RID: 18678
	public GameObject[] Student;
}
