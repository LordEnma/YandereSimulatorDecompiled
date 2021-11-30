using System;
using UnityEngine;

// Token: 0x02000347 RID: 839
public class KnifeArrayScript : MonoBehaviour
{
	// Token: 0x0600192D RID: 6445 RVA: 0x000FB774 File Offset: 0x000F9974
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.ID < 10)
		{
			if (this.Timer > this.SpawnTimes[this.ID] && this.GlobalKnifeArray.ID < 1000)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Knife, base.transform.position, Quaternion.identity);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localPosition = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(0.5f, 2f), UnityEngine.Random.Range(-0.75f, -1.75f));
				gameObject.transform.parent = null;
				gameObject.transform.LookAt(this.KnifeTarget);
				this.GlobalKnifeArray.Knives[this.GlobalKnifeArray.ID] = gameObject.GetComponent<TimeStopKnifeScript>();
				this.GlobalKnifeArray.ID++;
				this.ID++;
				return;
			}
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400278A RID: 10122
	public GlobalKnifeArrayScript GlobalKnifeArray;

	// Token: 0x0400278B RID: 10123
	public Transform KnifeTarget;

	// Token: 0x0400278C RID: 10124
	public float[] SpawnTimes;

	// Token: 0x0400278D RID: 10125
	public GameObject Knife;

	// Token: 0x0400278E RID: 10126
	public float Timer;

	// Token: 0x0400278F RID: 10127
	public int ID;
}
