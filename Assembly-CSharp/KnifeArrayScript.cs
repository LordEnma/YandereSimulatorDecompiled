using System;
using UnityEngine;

// Token: 0x02000348 RID: 840
public class KnifeArrayScript : MonoBehaviour
{
	// Token: 0x06001936 RID: 6454 RVA: 0x000FC244 File Offset: 0x000FA444
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

	// Token: 0x040027B3 RID: 10163
	public GlobalKnifeArrayScript GlobalKnifeArray;

	// Token: 0x040027B4 RID: 10164
	public Transform KnifeTarget;

	// Token: 0x040027B5 RID: 10165
	public float[] SpawnTimes;

	// Token: 0x040027B6 RID: 10166
	public GameObject Knife;

	// Token: 0x040027B7 RID: 10167
	public float Timer;

	// Token: 0x040027B8 RID: 10168
	public int ID;
}
