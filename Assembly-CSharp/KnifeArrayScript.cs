using System;
using UnityEngine;

// Token: 0x02000349 RID: 841
public class KnifeArrayScript : MonoBehaviour
{
	// Token: 0x0600193B RID: 6459 RVA: 0x000FCC00 File Offset: 0x000FAE00
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

	// Token: 0x040027C1 RID: 10177
	public GlobalKnifeArrayScript GlobalKnifeArray;

	// Token: 0x040027C2 RID: 10178
	public Transform KnifeTarget;

	// Token: 0x040027C3 RID: 10179
	public float[] SpawnTimes;

	// Token: 0x040027C4 RID: 10180
	public GameObject Knife;

	// Token: 0x040027C5 RID: 10181
	public float Timer;

	// Token: 0x040027C6 RID: 10182
	public int ID;
}
