using System;
using UnityEngine;

// Token: 0x02000522 RID: 1314
public class FoldingChairScript : MonoBehaviour
{
	// Token: 0x0600219F RID: 8607 RVA: 0x001F03B0 File Offset: 0x001EE5B0
	private void Start()
	{
		int num = UnityEngine.Random.Range(0, this.Student.Length);
		UnityEngine.Object.Instantiate<GameObject>(this.Student[num], base.transform.position - new Vector3(0f, 0.4f, 0f), base.transform.rotation);
	}

	// Token: 0x040049FD RID: 18941
	public GameObject[] Student;
}
