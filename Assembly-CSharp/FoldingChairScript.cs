using System;
using UnityEngine;

// Token: 0x0200051B RID: 1307
public class FoldingChairScript : MonoBehaviour
{
	// Token: 0x06002177 RID: 8567 RVA: 0x001EC728 File Offset: 0x001EA928
	private void Start()
	{
		int num = UnityEngine.Random.Range(0, this.Student.Length);
		UnityEngine.Object.Instantiate<GameObject>(this.Student[num], base.transform.position - new Vector3(0f, 0.4f, 0f), base.transform.rotation);
	}

	// Token: 0x0400499F RID: 18847
	public GameObject[] Student;
}
