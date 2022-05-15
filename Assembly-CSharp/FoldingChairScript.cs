using System;
using UnityEngine;

// Token: 0x02000523 RID: 1315
public class FoldingChairScript : MonoBehaviour
{
	// Token: 0x060021AA RID: 8618 RVA: 0x001F1AFC File Offset: 0x001EFCFC
	private void Start()
	{
		int num = UnityEngine.Random.Range(0, this.Student.Length);
		UnityEngine.Object.Instantiate<GameObject>(this.Student[num], base.transform.position - new Vector3(0f, 0.4f, 0f), base.transform.rotation);
	}

	// Token: 0x04004A24 RID: 18980
	public GameObject[] Student;
}
