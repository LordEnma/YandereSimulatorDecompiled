using System;
using UnityEngine;

// Token: 0x0200034B RID: 843
public class KnifeArrayScript : MonoBehaviour
{
	// Token: 0x0600194D RID: 6477 RVA: 0x000FDB20 File Offset: 0x000FBD20
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

	// Token: 0x040027EF RID: 10223
	public GlobalKnifeArrayScript GlobalKnifeArray;

	// Token: 0x040027F0 RID: 10224
	public Transform KnifeTarget;

	// Token: 0x040027F1 RID: 10225
	public float[] SpawnTimes;

	// Token: 0x040027F2 RID: 10226
	public GameObject Knife;

	// Token: 0x040027F3 RID: 10227
	public float Timer;

	// Token: 0x040027F4 RID: 10228
	public int ID;
}
