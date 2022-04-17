using System;
using UnityEngine;

// Token: 0x0200034D RID: 845
public class KnifeArrayScript : MonoBehaviour
{
	// Token: 0x06001964 RID: 6500 RVA: 0x000FECFC File Offset: 0x000FCEFC
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

	// Token: 0x0400282A RID: 10282
	public GlobalKnifeArrayScript GlobalKnifeArray;

	// Token: 0x0400282B RID: 10283
	public Transform KnifeTarget;

	// Token: 0x0400282C RID: 10284
	public float[] SpawnTimes;

	// Token: 0x0400282D RID: 10285
	public GameObject Knife;

	// Token: 0x0400282E RID: 10286
	public float Timer;

	// Token: 0x0400282F RID: 10287
	public int ID;
}
