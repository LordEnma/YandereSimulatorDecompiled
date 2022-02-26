using System;
using UnityEngine;

// Token: 0x0200034B RID: 843
public class KnifeArrayScript : MonoBehaviour
{
	// Token: 0x0600194D RID: 6477 RVA: 0x000FD7E0 File Offset: 0x000FB9E0
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

	// Token: 0x040027D9 RID: 10201
	public GlobalKnifeArrayScript GlobalKnifeArray;

	// Token: 0x040027DA RID: 10202
	public Transform KnifeTarget;

	// Token: 0x040027DB RID: 10203
	public float[] SpawnTimes;

	// Token: 0x040027DC RID: 10204
	public GameObject Knife;

	// Token: 0x040027DD RID: 10205
	public float Timer;

	// Token: 0x040027DE RID: 10206
	public int ID;
}
