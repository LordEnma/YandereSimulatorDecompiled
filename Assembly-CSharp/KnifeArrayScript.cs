using System;
using UnityEngine;

// Token: 0x0200034E RID: 846
public class KnifeArrayScript : MonoBehaviour
{
	// Token: 0x0600196F RID: 6511 RVA: 0x000FFC0C File Offset: 0x000FDE0C
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

	// Token: 0x0400284B RID: 10315
	public GlobalKnifeArrayScript GlobalKnifeArray;

	// Token: 0x0400284C RID: 10316
	public Transform KnifeTarget;

	// Token: 0x0400284D RID: 10317
	public float[] SpawnTimes;

	// Token: 0x0400284E RID: 10318
	public GameObject Knife;

	// Token: 0x0400284F RID: 10319
	public float Timer;

	// Token: 0x04002850 RID: 10320
	public int ID;
}
