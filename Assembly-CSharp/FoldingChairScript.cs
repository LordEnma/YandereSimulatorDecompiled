using System;
using UnityEngine;

// Token: 0x02000521 RID: 1313
public class FoldingChairScript : MonoBehaviour
{
	// Token: 0x06002196 RID: 8598 RVA: 0x001EEF24 File Offset: 0x001ED124
	private void Start()
	{
		int num = UnityEngine.Random.Range(0, this.Student.Length);
		UnityEngine.Object.Instantiate<GameObject>(this.Student[num], base.transform.position - new Vector3(0f, 0.4f, 0f), base.transform.rotation);
	}

	// Token: 0x040049E7 RID: 18919
	public GameObject[] Student;
}
