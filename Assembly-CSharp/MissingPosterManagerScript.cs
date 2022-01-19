﻿using System;
using UnityEngine;

// Token: 0x02000367 RID: 871
public class MissingPosterManagerScript : MonoBehaviour
{
	// Token: 0x060019A1 RID: 6561 RVA: 0x00105C4C File Offset: 0x00103E4C
	private void Start()
	{
		while (this.ID < 101)
		{
			if (StudentGlobals.GetStudentMissing(this.ID))
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.MissingPoster, base.transform.position, Quaternion.identity);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
				gameObject.transform.eulerAngles = new Vector3(0f, 0f, UnityEngine.Random.Range(-15f, 15f));
				WWW www = new WWW(string.Concat(new string[]
				{
					"file:///",
					Application.streamingAssetsPath,
					"/Portraits/Student_",
					this.ID.ToString(),
					".png"
				}));
				gameObject.GetComponent<MissingPosterScript>().MyRenderer.material.mainTexture = www.texture;
				this.RandomID = UnityEngine.Random.Range(1, 3);
				gameObject.transform.localPosition = new Vector3(-16300f + (float)(this.ID * 500), UnityEngine.Random.Range(1300f, 2000f), 0f);
				if (gameObject.transform.localPosition.x > -3700f)
				{
					gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + 7300f, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
				}
				if (gameObject.transform.localPosition.x > 15800f)
				{
					UnityEngine.Object.Destroy(gameObject);
				}
			}
			this.ID++;
		}
	}

	// Token: 0x04002905 RID: 10501
	public GameObject MissingPoster;

	// Token: 0x04002906 RID: 10502
	public int RandomID;

	// Token: 0x04002907 RID: 10503
	public int ID;
}
