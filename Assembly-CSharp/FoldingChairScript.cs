using System;
using UnityEngine;

// Token: 0x0200050F RID: 1295
public class FoldingChairScript : MonoBehaviour
{
	// Token: 0x0600211F RID: 8479 RVA: 0x001E4C04 File Offset: 0x001E2E04
	private void Start()
	{
		int num = UnityEngine.Random.Range(0, this.Student.Length);
		UnityEngine.Object.Instantiate<GameObject>(this.Student[num], base.transform.position - new Vector3(0f, 0.4f, 0f), base.transform.rotation);
	}

	// Token: 0x04004893 RID: 18579
	public GameObject[] Student;
}
