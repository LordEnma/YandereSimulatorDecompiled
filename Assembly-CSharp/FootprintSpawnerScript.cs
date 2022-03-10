using System;
using UnityEngine;

// Token: 0x020002D2 RID: 722
public class FootprintSpawnerScript : MonoBehaviour
{
	// Token: 0x060014B6 RID: 5302 RVA: 0x000CBCE0 File Offset: 0x000C9EE0
	private void Start()
	{
		if (this.MyAudio == null)
		{
			this.MyAudio = base.GetComponent<AudioSource>();
		}
		this.GardenArea = this.Yandere.StudentManager.GardenArea;
		this.PoolStairs = this.Yandere.StudentManager.PoolStairs;
		this.TreeArea = this.Yandere.StudentManager.TreeArea;
		this.NEStairs = this.Yandere.StudentManager.NEStairs;
		this.NWStairs = this.Yandere.StudentManager.NWStairs;
		this.SEStairs = this.Yandere.StudentManager.SEStairs;
		this.SWStairs = this.Yandere.StudentManager.SWStairs;
	}

	// Token: 0x060014B7 RID: 5303 RVA: 0x000CBDA4 File Offset: 0x000C9FA4
	private void Update()
	{
		if (!this.FootUp)
		{
			if (base.transform.position.y > this.Yandere.transform.position.y + this.UpThreshold)
			{
				this.FootUp = true;
				return;
			}
		}
		else if (base.transform.position.y < this.Yandere.transform.position.y + this.DownThreshold)
		{
			if (this.Yandere.Stance.Current != StanceType.Crouching && this.Yandere.Stance.Current != StanceType.Crawling && this.Yandere.CanMove && !this.Yandere.NearSenpai && this.FootUp)
			{
				if (this.Yandere.Schoolwear == 0 || this.Yandere.Schoolwear == 2)
				{
					if (this.Yandere.Running)
					{
						this.MyAudio.clip = this.RunBareFootsteps[UnityEngine.Random.Range(0, this.RunBareFootsteps.Length)];
						this.MyAudio.volume = 0.3f;
					}
					else
					{
						this.MyAudio.clip = this.WalkBareFootsteps[UnityEngine.Random.Range(0, this.WalkBareFootsteps.Length)];
						this.MyAudio.volume = 0.2f;
					}
				}
				else if (this.Yandere.Running)
				{
					this.MyAudio.clip = this.RunFootsteps[UnityEngine.Random.Range(0, this.RunFootsteps.Length)];
					this.MyAudio.volume = 0.15f;
				}
				else
				{
					this.MyAudio.clip = this.WalkFootsteps[UnityEngine.Random.Range(0, this.WalkFootsteps.Length)];
					this.MyAudio.volume = 0.1f;
				}
				this.MyAudio.Play();
			}
			this.FootUp = false;
			if (this.Bloodiness > 0)
			{
				this.CanSpawn = (!this.GardenArea.bounds.Contains(base.transform.position) && !this.PoolStairs.bounds.Contains(base.transform.position) && !this.TreeArea.bounds.Contains(base.transform.position) && !this.NEStairs.bounds.Contains(base.transform.position) && !this.NWStairs.bounds.Contains(base.transform.position) && !this.SEStairs.bounds.Contains(base.transform.position) && !this.SWStairs.bounds.Contains(base.transform.position));
				if (this.CanSpawn)
				{
					if (base.transform.position.y > -1f && base.transform.position.y < 1f)
					{
						this.Height = 0f;
					}
					else if (base.transform.position.y > 3f && base.transform.position.y < 5f)
					{
						this.Height = 4f;
					}
					else if (base.transform.position.y > 7f && base.transform.position.y < 9f)
					{
						this.Height = 8f;
					}
					else if (base.transform.position.y > 11f && base.transform.position.y < 13f)
					{
						this.Height = 12f;
					}
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodyFootprint, new Vector3(base.transform.position.x, this.Height + 0.012f, base.transform.position.z), Quaternion.identity);
					gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, base.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
					gameObject.transform.GetChild(0).GetComponent<FootprintScript>().Yandere = this.Yandere;
					gameObject.transform.parent = this.BloodParent;
					this.Bloodiness--;
				}
			}
		}
	}

	// Token: 0x04002071 RID: 8305
	public YandereScript Yandere;

	// Token: 0x04002072 RID: 8306
	public GameObject BloodyFootprint;

	// Token: 0x04002073 RID: 8307
	public AudioClip[] WalkFootsteps;

	// Token: 0x04002074 RID: 8308
	public AudioClip[] RunFootsteps;

	// Token: 0x04002075 RID: 8309
	public AudioClip[] WalkBareFootsteps;

	// Token: 0x04002076 RID: 8310
	public AudioClip[] RunBareFootsteps;

	// Token: 0x04002077 RID: 8311
	public AudioSource MyAudio;

	// Token: 0x04002078 RID: 8312
	public Transform BloodParent;

	// Token: 0x04002079 RID: 8313
	public Collider MyCollider;

	// Token: 0x0400207A RID: 8314
	public Collider GardenArea;

	// Token: 0x0400207B RID: 8315
	public Collider PoolStairs;

	// Token: 0x0400207C RID: 8316
	public Collider TreeArea;

	// Token: 0x0400207D RID: 8317
	public Collider NEStairs;

	// Token: 0x0400207E RID: 8318
	public Collider NWStairs;

	// Token: 0x0400207F RID: 8319
	public Collider SEStairs;

	// Token: 0x04002080 RID: 8320
	public Collider SWStairs;

	// Token: 0x04002081 RID: 8321
	public bool Debugging;

	// Token: 0x04002082 RID: 8322
	public bool CanSpawn;

	// Token: 0x04002083 RID: 8323
	public bool FootUp;

	// Token: 0x04002084 RID: 8324
	public float DownThreshold;

	// Token: 0x04002085 RID: 8325
	public float UpThreshold;

	// Token: 0x04002086 RID: 8326
	public float Height;

	// Token: 0x04002087 RID: 8327
	public int Bloodiness;

	// Token: 0x04002088 RID: 8328
	public int Collisions;
}
