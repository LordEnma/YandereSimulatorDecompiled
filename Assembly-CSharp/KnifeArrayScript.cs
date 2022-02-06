using System;
using UnityEngine;

// Token: 0x02000349 RID: 841
public class KnifeArrayScript : MonoBehaviour
{
	// Token: 0x0600193D RID: 6461 RVA: 0x000FCD0C File Offset: 0x000FAF0C
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

	// Token: 0x040027C4 RID: 10180
	public GlobalKnifeArrayScript GlobalKnifeArray;

	// Token: 0x040027C5 RID: 10181
	public Transform KnifeTarget;

	// Token: 0x040027C6 RID: 10182
	public float[] SpawnTimes;

	// Token: 0x040027C7 RID: 10183
	public GameObject Knife;

	// Token: 0x040027C8 RID: 10184
	public float Timer;

	// Token: 0x040027C9 RID: 10185
	public int ID;
}
