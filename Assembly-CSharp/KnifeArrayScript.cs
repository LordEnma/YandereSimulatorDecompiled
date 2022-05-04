using System;
using UnityEngine;

// Token: 0x0200034D RID: 845
public class KnifeArrayScript : MonoBehaviour
{
	// Token: 0x06001968 RID: 6504 RVA: 0x000FF1CC File Offset: 0x000FD3CC
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

	// Token: 0x04002833 RID: 10291
	public GlobalKnifeArrayScript GlobalKnifeArray;

	// Token: 0x04002834 RID: 10292
	public Transform KnifeTarget;

	// Token: 0x04002835 RID: 10293
	public float[] SpawnTimes;

	// Token: 0x04002836 RID: 10294
	public GameObject Knife;

	// Token: 0x04002837 RID: 10295
	public float Timer;

	// Token: 0x04002838 RID: 10296
	public int ID;
}
