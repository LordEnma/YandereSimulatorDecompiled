using System;
using UnityEngine;

// Token: 0x0200034A RID: 842
public class KnifeArrayScript : MonoBehaviour
{
	// Token: 0x06001944 RID: 6468 RVA: 0x000FCEB0 File Offset: 0x000FB0B0
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

	// Token: 0x040027CA RID: 10186
	public GlobalKnifeArrayScript GlobalKnifeArray;

	// Token: 0x040027CB RID: 10187
	public Transform KnifeTarget;

	// Token: 0x040027CC RID: 10188
	public float[] SpawnTimes;

	// Token: 0x040027CD RID: 10189
	public GameObject Knife;

	// Token: 0x040027CE RID: 10190
	public float Timer;

	// Token: 0x040027CF RID: 10191
	public int ID;
}
