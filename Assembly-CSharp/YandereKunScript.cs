using System;
using UnityEngine;

// Token: 0x020004CB RID: 1227
public class YandereKunScript : MonoBehaviour
{
	// Token: 0x06002019 RID: 8217 RVA: 0x001C9D0C File Offset: 0x001C7F0C
	private void Start()
	{
		if (!this.Kizuna)
		{
			if (this.KunHips != null)
			{
				this.KunHips.parent = this.ChanHips;
			}
			if (this.KunSpine != null)
			{
				this.KunSpine.parent = this.ChanSpine;
			}
			if (this.KunSpine1 != null)
			{
				this.KunSpine1.parent = this.ChanSpine1;
			}
			if (this.KunSpine2 != null)
			{
				this.KunSpine2.parent = this.ChanSpine2;
			}
			if (this.KunSpine3 != null)
			{
				this.KunSpine3.parent = this.ChanSpine3;
			}
			if (this.KunNeck != null)
			{
				this.KunNeck.parent = this.ChanNeck;
			}
			if (this.KunHead != null)
			{
				this.KunHead.parent = this.ChanHead;
			}
			this.KunRightUpLeg.parent = this.ChanRightUpLeg;
			this.KunRightLeg.parent = this.ChanRightLeg;
			this.KunRightFoot.parent = this.ChanRightFoot;
			this.KunRightToes.parent = this.ChanRightToes;
			this.KunLeftUpLeg.parent = this.ChanLeftUpLeg;
			this.KunLeftLeg.parent = this.ChanLeftLeg;
			this.KunLeftFoot.parent = this.ChanLeftFoot;
			this.KunLeftToes.parent = this.ChanLeftToes;
			this.KunRightShoulder.parent = this.ChanRightShoulder;
			this.KunRightArm.parent = this.ChanRightArm;
			if (this.KunRightArmRoll != null)
			{
				this.KunRightArmRoll.parent = this.ChanRightArmRoll;
			}
			this.KunRightForeArm.parent = this.ChanRightForeArm;
			if (this.KunRightForeArmRoll != null)
			{
				this.KunRightForeArmRoll.parent = this.ChanRightForeArmRoll;
			}
			this.KunRightHand.parent = this.ChanRightHand;
			this.KunLeftShoulder.parent = this.ChanLeftShoulder;
			this.KunLeftArm.parent = this.ChanLeftArm;
			if (this.KunLeftArmRoll != null)
			{
				this.KunLeftArmRoll.parent = this.ChanLeftArmRoll;
			}
			this.KunLeftForeArm.parent = this.ChanLeftForeArm;
			if (this.KunLeftForeArmRoll != null)
			{
				this.KunLeftForeArmRoll.parent = this.ChanLeftForeArmRoll;
			}
			this.KunLeftHand.parent = this.ChanLeftHand;
			if (!this.Man)
			{
				this.KunLeftHandPinky1.parent = this.ChanLeftHandPinky1;
				this.KunLeftHandPinky2.parent = this.ChanLeftHandPinky2;
				this.KunLeftHandPinky3.parent = this.ChanLeftHandPinky3;
				this.KunLeftHandRing1.parent = this.ChanLeftHandRing1;
				this.KunLeftHandRing2.parent = this.ChanLeftHandRing2;
				this.KunLeftHandRing3.parent = this.ChanLeftHandRing3;
				this.KunLeftHandMiddle1.parent = this.ChanLeftHandMiddle1;
				this.KunLeftHandMiddle2.parent = this.ChanLeftHandMiddle2;
				this.KunLeftHandMiddle3.parent = this.ChanLeftHandMiddle3;
				this.KunLeftHandIndex1.parent = this.ChanLeftHandIndex1;
				this.KunLeftHandIndex2.parent = this.ChanLeftHandIndex2;
				this.KunLeftHandIndex3.parent = this.ChanLeftHandIndex3;
				this.KunLeftHandThumb1.parent = this.ChanLeftHandThumb1;
				this.KunLeftHandThumb2.parent = this.ChanLeftHandThumb2;
				this.KunLeftHandThumb3.parent = this.ChanLeftHandThumb3;
				this.KunRightHandPinky1.parent = this.ChanRightHandPinky1;
				this.KunRightHandPinky2.parent = this.ChanRightHandPinky2;
				this.KunRightHandPinky3.parent = this.ChanRightHandPinky3;
				this.KunRightHandRing1.parent = this.ChanRightHandRing1;
				this.KunRightHandRing2.parent = this.ChanRightHandRing2;
				this.KunRightHandRing3.parent = this.ChanRightHandRing3;
				this.KunRightHandMiddle1.parent = this.ChanRightHandMiddle1;
				this.KunRightHandMiddle2.parent = this.ChanRightHandMiddle2;
				this.KunRightHandMiddle3.parent = this.ChanRightHandMiddle3;
				this.KunRightHandIndex1.parent = this.ChanRightHandIndex1;
				this.KunRightHandIndex2.parent = this.ChanRightHandIndex2;
				this.KunRightHandIndex3.parent = this.ChanRightHandIndex3;
				this.KunRightHandThumb1.parent = this.ChanRightHandThumb1;
				this.KunRightHandThumb2.parent = this.ChanRightHandThumb2;
				this.KunRightHandThumb3.parent = this.ChanRightHandThumb3;
			}
		}
		if (this.MyRenderer != null)
		{
			this.MyRenderer.enabled = true;
		}
		if (this.SecondRenderer != null)
		{
			this.SecondRenderer.enabled = true;
		}
		if (this.ThirdRenderer != null)
		{
			this.ThirdRenderer.enabled = true;
		}
		base.gameObject.SetActive(false);
	}

	// Token: 0x0600201A RID: 8218 RVA: 0x001CA1EC File Offset: 0x001C83EC
	private void LateUpdate()
	{
		if (this.Man)
		{
			this.ChanItemParent.position = this.KunItemParent.position;
			if (!this.Adjusted)
			{
				this.KunRightShoulder.position += new Vector3(0f, 0.1f, 0f);
				this.KunRightArm.position += new Vector3(0f, 0.1f, 0f);
				this.KunRightForeArm.position += new Vector3(0f, 0.1f, 0f);
				this.KunRightHand.position += new Vector3(0f, 0.1f, 0f);
				this.KunLeftShoulder.position += new Vector3(0f, 0.1f, 0f);
				this.KunLeftArm.position += new Vector3(0f, 0.1f, 0f);
				this.KunLeftForeArm.position += new Vector3(0f, 0.1f, 0f);
				this.KunLeftHand.position += new Vector3(0f, 0.1f, 0f);
				this.Adjusted = true;
			}
		}
		if (this.Kizuna)
		{
			this.KunItemParent.localPosition = new Vector3(0.066666f, -0.033333f, 0.02f);
			this.ChanItemParent.position = this.KunItemParent.position;
			this.KunHips.localPosition = this.ChanHips.localPosition;
			if (this.KunHips != null)
			{
				this.KunHips.eulerAngles = this.ChanHips.eulerAngles;
			}
			if (this.KunSpine != null)
			{
				this.KunSpine.eulerAngles = this.ChanSpine.eulerAngles;
			}
			if (this.KunSpine1 != null)
			{
				this.KunSpine1.eulerAngles = this.ChanSpine1.eulerAngles;
			}
			if (this.KunSpine2 != null)
			{
				this.KunSpine2.eulerAngles = this.ChanSpine2.eulerAngles;
			}
			if (this.KunSpine3 != null)
			{
				this.KunSpine3.eulerAngles = this.ChanSpine3.eulerAngles;
			}
			if (this.KunNeck != null)
			{
				this.KunNeck.eulerAngles = this.ChanNeck.eulerAngles;
			}
			if (this.KunHead != null)
			{
				this.KunHead.eulerAngles = this.ChanHead.eulerAngles;
			}
			this.KunRightUpLeg.eulerAngles = this.ChanRightUpLeg.eulerAngles;
			this.KunRightLeg.eulerAngles = this.ChanRightLeg.eulerAngles;
			this.KunRightFoot.eulerAngles = this.ChanRightFoot.eulerAngles;
			this.KunRightToes.eulerAngles = this.ChanRightToes.eulerAngles;
			this.KunLeftUpLeg.eulerAngles = this.ChanLeftUpLeg.eulerAngles;
			this.KunLeftLeg.eulerAngles = this.ChanLeftLeg.eulerAngles;
			this.KunLeftFoot.eulerAngles = this.ChanLeftFoot.eulerAngles;
			this.KunLeftToes.eulerAngles = this.ChanLeftToes.eulerAngles;
			this.KunRightShoulder.eulerAngles = this.ChanRightShoulder.eulerAngles;
			this.KunRightArm.eulerAngles = this.ChanRightArm.eulerAngles;
			if (this.KunLeftArmRoll != null)
			{
				this.KunRightArmRoll.eulerAngles = this.ChanRightArmRoll.eulerAngles;
			}
			this.KunRightForeArm.eulerAngles = this.ChanRightForeArm.eulerAngles;
			if (this.KunLeftArmRoll != null)
			{
				this.KunRightForeArmRoll.eulerAngles = this.ChanRightForeArmRoll.eulerAngles;
			}
			this.KunRightHand.eulerAngles = this.ChanRightHand.eulerAngles;
			this.KunLeftShoulder.eulerAngles = this.ChanLeftShoulder.eulerAngles;
			this.KunLeftArm.eulerAngles = this.ChanLeftArm.eulerAngles;
			if (this.KunLeftArmRoll != null)
			{
				this.KunLeftArmRoll.eulerAngles = this.ChanLeftArmRoll.eulerAngles;
			}
			this.KunLeftForeArm.eulerAngles = this.ChanLeftForeArm.eulerAngles;
			if (this.KunLeftForeArmRoll != null)
			{
				this.KunLeftForeArmRoll.eulerAngles = this.ChanLeftForeArmRoll.eulerAngles;
			}
			this.KunLeftHand.eulerAngles = this.ChanLeftHand.eulerAngles;
			this.KunLeftHandPinky1.eulerAngles = this.ChanLeftHandPinky1.eulerAngles;
			this.KunLeftHandPinky2.eulerAngles = this.ChanLeftHandPinky2.eulerAngles;
			this.KunLeftHandPinky3.eulerAngles = this.ChanLeftHandPinky3.eulerAngles;
			this.KunLeftHandRing1.eulerAngles = this.ChanLeftHandRing1.eulerAngles;
			this.KunLeftHandRing2.eulerAngles = this.ChanLeftHandRing2.eulerAngles;
			this.KunLeftHandRing3.eulerAngles = this.ChanLeftHandRing3.eulerAngles;
			this.KunLeftHandMiddle1.eulerAngles = this.ChanLeftHandMiddle1.eulerAngles;
			this.KunLeftHandMiddle2.eulerAngles = this.ChanLeftHandMiddle2.eulerAngles;
			this.KunLeftHandMiddle3.eulerAngles = this.ChanLeftHandMiddle3.eulerAngles;
			this.KunLeftHandIndex1.eulerAngles = this.ChanLeftHandIndex1.eulerAngles;
			this.KunLeftHandIndex2.eulerAngles = this.ChanLeftHandIndex2.eulerAngles;
			this.KunLeftHandIndex3.eulerAngles = this.ChanLeftHandIndex3.eulerAngles;
			this.KunLeftHandThumb1.eulerAngles = this.ChanLeftHandThumb1.eulerAngles;
			this.KunLeftHandThumb2.eulerAngles = this.ChanLeftHandThumb2.eulerAngles;
			this.KunLeftHandThumb3.eulerAngles = this.ChanLeftHandThumb3.eulerAngles;
			this.KunRightHandPinky1.eulerAngles = this.ChanRightHandPinky1.eulerAngles;
			this.KunRightHandPinky2.eulerAngles = this.ChanRightHandPinky2.eulerAngles;
			this.KunRightHandPinky3.eulerAngles = this.ChanRightHandPinky3.eulerAngles;
			this.KunRightHandRing1.eulerAngles = this.ChanRightHandRing1.eulerAngles;
			this.KunRightHandRing2.eulerAngles = this.ChanRightHandRing2.eulerAngles;
			this.KunRightHandRing3.eulerAngles = this.ChanRightHandRing3.eulerAngles;
			this.KunRightHandMiddle1.eulerAngles = this.ChanRightHandMiddle1.eulerAngles;
			this.KunRightHandMiddle2.eulerAngles = this.ChanRightHandMiddle2.eulerAngles;
			this.KunRightHandMiddle3.eulerAngles = this.ChanRightHandMiddle3.eulerAngles;
			this.KunRightHandIndex1.eulerAngles = this.ChanRightHandIndex1.eulerAngles;
			this.KunRightHandIndex2.eulerAngles = this.ChanRightHandIndex2.eulerAngles;
			this.KunRightHandIndex3.eulerAngles = this.ChanRightHandIndex3.eulerAngles;
			this.KunRightHandThumb1.eulerAngles = this.ChanRightHandThumb1.eulerAngles;
			this.KunRightHandThumb2.eulerAngles = this.ChanRightHandThumb2.eulerAngles;
			this.KunRightHandThumb3.eulerAngles = this.ChanRightHandThumb3.eulerAngles;
			if (Input.GetKeyDown(KeyCode.Space))
			{
				if (this.ID > -1)
				{
					for (int i = 0; i < 32; i++)
					{
						this.SecondRenderer.SetBlendShapeWeight(i, 0f);
					}
					if (this.ID > 32)
					{
						this.ID = 0;
					}
					this.SecondRenderer.SetBlendShapeWeight(this.ID, 100f);
				}
				this.ID++;
			}
		}
	}

	// Token: 0x040043C9 RID: 17353
	public Transform ChanItemParent;

	// Token: 0x040043CA RID: 17354
	public Transform KunItemParent;

	// Token: 0x040043CB RID: 17355
	public Transform ChanHips;

	// Token: 0x040043CC RID: 17356
	public Transform ChanSpine;

	// Token: 0x040043CD RID: 17357
	public Transform ChanSpine1;

	// Token: 0x040043CE RID: 17358
	public Transform ChanSpine2;

	// Token: 0x040043CF RID: 17359
	public Transform ChanSpine3;

	// Token: 0x040043D0 RID: 17360
	public Transform ChanNeck;

	// Token: 0x040043D1 RID: 17361
	public Transform ChanHead;

	// Token: 0x040043D2 RID: 17362
	public Transform ChanRightUpLeg;

	// Token: 0x040043D3 RID: 17363
	public Transform ChanRightLeg;

	// Token: 0x040043D4 RID: 17364
	public Transform ChanRightFoot;

	// Token: 0x040043D5 RID: 17365
	public Transform ChanRightToes;

	// Token: 0x040043D6 RID: 17366
	public Transform ChanLeftUpLeg;

	// Token: 0x040043D7 RID: 17367
	public Transform ChanLeftLeg;

	// Token: 0x040043D8 RID: 17368
	public Transform ChanLeftFoot;

	// Token: 0x040043D9 RID: 17369
	public Transform ChanLeftToes;

	// Token: 0x040043DA RID: 17370
	public Transform ChanRightShoulder;

	// Token: 0x040043DB RID: 17371
	public Transform ChanRightArm;

	// Token: 0x040043DC RID: 17372
	public Transform ChanRightArmRoll;

	// Token: 0x040043DD RID: 17373
	public Transform ChanRightForeArm;

	// Token: 0x040043DE RID: 17374
	public Transform ChanRightForeArmRoll;

	// Token: 0x040043DF RID: 17375
	public Transform ChanRightHand;

	// Token: 0x040043E0 RID: 17376
	public Transform ChanLeftShoulder;

	// Token: 0x040043E1 RID: 17377
	public Transform ChanLeftArm;

	// Token: 0x040043E2 RID: 17378
	public Transform ChanLeftArmRoll;

	// Token: 0x040043E3 RID: 17379
	public Transform ChanLeftForeArm;

	// Token: 0x040043E4 RID: 17380
	public Transform ChanLeftForeArmRoll;

	// Token: 0x040043E5 RID: 17381
	public Transform ChanLeftHand;

	// Token: 0x040043E6 RID: 17382
	public Transform ChanLeftHandPinky1;

	// Token: 0x040043E7 RID: 17383
	public Transform ChanLeftHandPinky2;

	// Token: 0x040043E8 RID: 17384
	public Transform ChanLeftHandPinky3;

	// Token: 0x040043E9 RID: 17385
	public Transform ChanLeftHandRing1;

	// Token: 0x040043EA RID: 17386
	public Transform ChanLeftHandRing2;

	// Token: 0x040043EB RID: 17387
	public Transform ChanLeftHandRing3;

	// Token: 0x040043EC RID: 17388
	public Transform ChanLeftHandMiddle1;

	// Token: 0x040043ED RID: 17389
	public Transform ChanLeftHandMiddle2;

	// Token: 0x040043EE RID: 17390
	public Transform ChanLeftHandMiddle3;

	// Token: 0x040043EF RID: 17391
	public Transform ChanLeftHandIndex1;

	// Token: 0x040043F0 RID: 17392
	public Transform ChanLeftHandIndex2;

	// Token: 0x040043F1 RID: 17393
	public Transform ChanLeftHandIndex3;

	// Token: 0x040043F2 RID: 17394
	public Transform ChanLeftHandThumb1;

	// Token: 0x040043F3 RID: 17395
	public Transform ChanLeftHandThumb2;

	// Token: 0x040043F4 RID: 17396
	public Transform ChanLeftHandThumb3;

	// Token: 0x040043F5 RID: 17397
	public Transform ChanRightHandPinky1;

	// Token: 0x040043F6 RID: 17398
	public Transform ChanRightHandPinky2;

	// Token: 0x040043F7 RID: 17399
	public Transform ChanRightHandPinky3;

	// Token: 0x040043F8 RID: 17400
	public Transform ChanRightHandRing1;

	// Token: 0x040043F9 RID: 17401
	public Transform ChanRightHandRing2;

	// Token: 0x040043FA RID: 17402
	public Transform ChanRightHandRing3;

	// Token: 0x040043FB RID: 17403
	public Transform ChanRightHandMiddle1;

	// Token: 0x040043FC RID: 17404
	public Transform ChanRightHandMiddle2;

	// Token: 0x040043FD RID: 17405
	public Transform ChanRightHandMiddle3;

	// Token: 0x040043FE RID: 17406
	public Transform ChanRightHandIndex1;

	// Token: 0x040043FF RID: 17407
	public Transform ChanRightHandIndex2;

	// Token: 0x04004400 RID: 17408
	public Transform ChanRightHandIndex3;

	// Token: 0x04004401 RID: 17409
	public Transform ChanRightHandThumb1;

	// Token: 0x04004402 RID: 17410
	public Transform ChanRightHandThumb2;

	// Token: 0x04004403 RID: 17411
	public Transform ChanRightHandThumb3;

	// Token: 0x04004404 RID: 17412
	public Transform KunHips;

	// Token: 0x04004405 RID: 17413
	public Transform KunSpine;

	// Token: 0x04004406 RID: 17414
	public Transform KunSpine1;

	// Token: 0x04004407 RID: 17415
	public Transform KunSpine2;

	// Token: 0x04004408 RID: 17416
	public Transform KunSpine3;

	// Token: 0x04004409 RID: 17417
	public Transform KunNeck;

	// Token: 0x0400440A RID: 17418
	public Transform KunHead;

	// Token: 0x0400440B RID: 17419
	public Transform KunRightUpLeg;

	// Token: 0x0400440C RID: 17420
	public Transform KunRightLeg;

	// Token: 0x0400440D RID: 17421
	public Transform KunRightFoot;

	// Token: 0x0400440E RID: 17422
	public Transform KunRightToes;

	// Token: 0x0400440F RID: 17423
	public Transform KunLeftUpLeg;

	// Token: 0x04004410 RID: 17424
	public Transform KunLeftLeg;

	// Token: 0x04004411 RID: 17425
	public Transform KunLeftFoot;

	// Token: 0x04004412 RID: 17426
	public Transform KunLeftToes;

	// Token: 0x04004413 RID: 17427
	public Transform KunRightShoulder;

	// Token: 0x04004414 RID: 17428
	public Transform KunRightArm;

	// Token: 0x04004415 RID: 17429
	public Transform KunRightArmRoll;

	// Token: 0x04004416 RID: 17430
	public Transform KunRightForeArm;

	// Token: 0x04004417 RID: 17431
	public Transform KunRightForeArmRoll;

	// Token: 0x04004418 RID: 17432
	public Transform KunRightHand;

	// Token: 0x04004419 RID: 17433
	public Transform KunLeftShoulder;

	// Token: 0x0400441A RID: 17434
	public Transform KunLeftArm;

	// Token: 0x0400441B RID: 17435
	public Transform KunLeftArmRoll;

	// Token: 0x0400441C RID: 17436
	public Transform KunLeftForeArm;

	// Token: 0x0400441D RID: 17437
	public Transform KunLeftForeArmRoll;

	// Token: 0x0400441E RID: 17438
	public Transform KunLeftHand;

	// Token: 0x0400441F RID: 17439
	public Transform KunLeftHandPinky1;

	// Token: 0x04004420 RID: 17440
	public Transform KunLeftHandPinky2;

	// Token: 0x04004421 RID: 17441
	public Transform KunLeftHandPinky3;

	// Token: 0x04004422 RID: 17442
	public Transform KunLeftHandRing1;

	// Token: 0x04004423 RID: 17443
	public Transform KunLeftHandRing2;

	// Token: 0x04004424 RID: 17444
	public Transform KunLeftHandRing3;

	// Token: 0x04004425 RID: 17445
	public Transform KunLeftHandMiddle1;

	// Token: 0x04004426 RID: 17446
	public Transform KunLeftHandMiddle2;

	// Token: 0x04004427 RID: 17447
	public Transform KunLeftHandMiddle3;

	// Token: 0x04004428 RID: 17448
	public Transform KunLeftHandIndex1;

	// Token: 0x04004429 RID: 17449
	public Transform KunLeftHandIndex2;

	// Token: 0x0400442A RID: 17450
	public Transform KunLeftHandIndex3;

	// Token: 0x0400442B RID: 17451
	public Transform KunLeftHandThumb1;

	// Token: 0x0400442C RID: 17452
	public Transform KunLeftHandThumb2;

	// Token: 0x0400442D RID: 17453
	public Transform KunLeftHandThumb3;

	// Token: 0x0400442E RID: 17454
	public Transform KunRightHandPinky1;

	// Token: 0x0400442F RID: 17455
	public Transform KunRightHandPinky2;

	// Token: 0x04004430 RID: 17456
	public Transform KunRightHandPinky3;

	// Token: 0x04004431 RID: 17457
	public Transform KunRightHandRing1;

	// Token: 0x04004432 RID: 17458
	public Transform KunRightHandRing2;

	// Token: 0x04004433 RID: 17459
	public Transform KunRightHandRing3;

	// Token: 0x04004434 RID: 17460
	public Transform KunRightHandMiddle1;

	// Token: 0x04004435 RID: 17461
	public Transform KunRightHandMiddle2;

	// Token: 0x04004436 RID: 17462
	public Transform KunRightHandMiddle3;

	// Token: 0x04004437 RID: 17463
	public Transform KunRightHandIndex1;

	// Token: 0x04004438 RID: 17464
	public Transform KunRightHandIndex2;

	// Token: 0x04004439 RID: 17465
	public Transform KunRightHandIndex3;

	// Token: 0x0400443A RID: 17466
	public Transform KunRightHandThumb1;

	// Token: 0x0400443B RID: 17467
	public Transform KunRightHandThumb2;

	// Token: 0x0400443C RID: 17468
	public Transform KunRightHandThumb3;

	// Token: 0x0400443D RID: 17469
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x0400443E RID: 17470
	public SkinnedMeshRenderer SecondRenderer;

	// Token: 0x0400443F RID: 17471
	public SkinnedMeshRenderer ThirdRenderer;

	// Token: 0x04004440 RID: 17472
	public bool Kizuna;

	// Token: 0x04004441 RID: 17473
	public bool Man;

	// Token: 0x04004442 RID: 17474
	public int ID;

	// Token: 0x04004443 RID: 17475
	private bool Adjusted;
}
