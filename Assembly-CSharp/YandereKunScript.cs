using System;
using UnityEngine;

// Token: 0x020004C7 RID: 1223
public class YandereKunScript : MonoBehaviour
{
	// Token: 0x06002003 RID: 8195 RVA: 0x001C7FC0 File Offset: 0x001C61C0
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

	// Token: 0x06002004 RID: 8196 RVA: 0x001C84A0 File Offset: 0x001C66A0
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

	// Token: 0x0400436E RID: 17262
	public Transform ChanItemParent;

	// Token: 0x0400436F RID: 17263
	public Transform KunItemParent;

	// Token: 0x04004370 RID: 17264
	public Transform ChanHips;

	// Token: 0x04004371 RID: 17265
	public Transform ChanSpine;

	// Token: 0x04004372 RID: 17266
	public Transform ChanSpine1;

	// Token: 0x04004373 RID: 17267
	public Transform ChanSpine2;

	// Token: 0x04004374 RID: 17268
	public Transform ChanSpine3;

	// Token: 0x04004375 RID: 17269
	public Transform ChanNeck;

	// Token: 0x04004376 RID: 17270
	public Transform ChanHead;

	// Token: 0x04004377 RID: 17271
	public Transform ChanRightUpLeg;

	// Token: 0x04004378 RID: 17272
	public Transform ChanRightLeg;

	// Token: 0x04004379 RID: 17273
	public Transform ChanRightFoot;

	// Token: 0x0400437A RID: 17274
	public Transform ChanRightToes;

	// Token: 0x0400437B RID: 17275
	public Transform ChanLeftUpLeg;

	// Token: 0x0400437C RID: 17276
	public Transform ChanLeftLeg;

	// Token: 0x0400437D RID: 17277
	public Transform ChanLeftFoot;

	// Token: 0x0400437E RID: 17278
	public Transform ChanLeftToes;

	// Token: 0x0400437F RID: 17279
	public Transform ChanRightShoulder;

	// Token: 0x04004380 RID: 17280
	public Transform ChanRightArm;

	// Token: 0x04004381 RID: 17281
	public Transform ChanRightArmRoll;

	// Token: 0x04004382 RID: 17282
	public Transform ChanRightForeArm;

	// Token: 0x04004383 RID: 17283
	public Transform ChanRightForeArmRoll;

	// Token: 0x04004384 RID: 17284
	public Transform ChanRightHand;

	// Token: 0x04004385 RID: 17285
	public Transform ChanLeftShoulder;

	// Token: 0x04004386 RID: 17286
	public Transform ChanLeftArm;

	// Token: 0x04004387 RID: 17287
	public Transform ChanLeftArmRoll;

	// Token: 0x04004388 RID: 17288
	public Transform ChanLeftForeArm;

	// Token: 0x04004389 RID: 17289
	public Transform ChanLeftForeArmRoll;

	// Token: 0x0400438A RID: 17290
	public Transform ChanLeftHand;

	// Token: 0x0400438B RID: 17291
	public Transform ChanLeftHandPinky1;

	// Token: 0x0400438C RID: 17292
	public Transform ChanLeftHandPinky2;

	// Token: 0x0400438D RID: 17293
	public Transform ChanLeftHandPinky3;

	// Token: 0x0400438E RID: 17294
	public Transform ChanLeftHandRing1;

	// Token: 0x0400438F RID: 17295
	public Transform ChanLeftHandRing2;

	// Token: 0x04004390 RID: 17296
	public Transform ChanLeftHandRing3;

	// Token: 0x04004391 RID: 17297
	public Transform ChanLeftHandMiddle1;

	// Token: 0x04004392 RID: 17298
	public Transform ChanLeftHandMiddle2;

	// Token: 0x04004393 RID: 17299
	public Transform ChanLeftHandMiddle3;

	// Token: 0x04004394 RID: 17300
	public Transform ChanLeftHandIndex1;

	// Token: 0x04004395 RID: 17301
	public Transform ChanLeftHandIndex2;

	// Token: 0x04004396 RID: 17302
	public Transform ChanLeftHandIndex3;

	// Token: 0x04004397 RID: 17303
	public Transform ChanLeftHandThumb1;

	// Token: 0x04004398 RID: 17304
	public Transform ChanLeftHandThumb2;

	// Token: 0x04004399 RID: 17305
	public Transform ChanLeftHandThumb3;

	// Token: 0x0400439A RID: 17306
	public Transform ChanRightHandPinky1;

	// Token: 0x0400439B RID: 17307
	public Transform ChanRightHandPinky2;

	// Token: 0x0400439C RID: 17308
	public Transform ChanRightHandPinky3;

	// Token: 0x0400439D RID: 17309
	public Transform ChanRightHandRing1;

	// Token: 0x0400439E RID: 17310
	public Transform ChanRightHandRing2;

	// Token: 0x0400439F RID: 17311
	public Transform ChanRightHandRing3;

	// Token: 0x040043A0 RID: 17312
	public Transform ChanRightHandMiddle1;

	// Token: 0x040043A1 RID: 17313
	public Transform ChanRightHandMiddle2;

	// Token: 0x040043A2 RID: 17314
	public Transform ChanRightHandMiddle3;

	// Token: 0x040043A3 RID: 17315
	public Transform ChanRightHandIndex1;

	// Token: 0x040043A4 RID: 17316
	public Transform ChanRightHandIndex2;

	// Token: 0x040043A5 RID: 17317
	public Transform ChanRightHandIndex3;

	// Token: 0x040043A6 RID: 17318
	public Transform ChanRightHandThumb1;

	// Token: 0x040043A7 RID: 17319
	public Transform ChanRightHandThumb2;

	// Token: 0x040043A8 RID: 17320
	public Transform ChanRightHandThumb3;

	// Token: 0x040043A9 RID: 17321
	public Transform KunHips;

	// Token: 0x040043AA RID: 17322
	public Transform KunSpine;

	// Token: 0x040043AB RID: 17323
	public Transform KunSpine1;

	// Token: 0x040043AC RID: 17324
	public Transform KunSpine2;

	// Token: 0x040043AD RID: 17325
	public Transform KunSpine3;

	// Token: 0x040043AE RID: 17326
	public Transform KunNeck;

	// Token: 0x040043AF RID: 17327
	public Transform KunHead;

	// Token: 0x040043B0 RID: 17328
	public Transform KunRightUpLeg;

	// Token: 0x040043B1 RID: 17329
	public Transform KunRightLeg;

	// Token: 0x040043B2 RID: 17330
	public Transform KunRightFoot;

	// Token: 0x040043B3 RID: 17331
	public Transform KunRightToes;

	// Token: 0x040043B4 RID: 17332
	public Transform KunLeftUpLeg;

	// Token: 0x040043B5 RID: 17333
	public Transform KunLeftLeg;

	// Token: 0x040043B6 RID: 17334
	public Transform KunLeftFoot;

	// Token: 0x040043B7 RID: 17335
	public Transform KunLeftToes;

	// Token: 0x040043B8 RID: 17336
	public Transform KunRightShoulder;

	// Token: 0x040043B9 RID: 17337
	public Transform KunRightArm;

	// Token: 0x040043BA RID: 17338
	public Transform KunRightArmRoll;

	// Token: 0x040043BB RID: 17339
	public Transform KunRightForeArm;

	// Token: 0x040043BC RID: 17340
	public Transform KunRightForeArmRoll;

	// Token: 0x040043BD RID: 17341
	public Transform KunRightHand;

	// Token: 0x040043BE RID: 17342
	public Transform KunLeftShoulder;

	// Token: 0x040043BF RID: 17343
	public Transform KunLeftArm;

	// Token: 0x040043C0 RID: 17344
	public Transform KunLeftArmRoll;

	// Token: 0x040043C1 RID: 17345
	public Transform KunLeftForeArm;

	// Token: 0x040043C2 RID: 17346
	public Transform KunLeftForeArmRoll;

	// Token: 0x040043C3 RID: 17347
	public Transform KunLeftHand;

	// Token: 0x040043C4 RID: 17348
	public Transform KunLeftHandPinky1;

	// Token: 0x040043C5 RID: 17349
	public Transform KunLeftHandPinky2;

	// Token: 0x040043C6 RID: 17350
	public Transform KunLeftHandPinky3;

	// Token: 0x040043C7 RID: 17351
	public Transform KunLeftHandRing1;

	// Token: 0x040043C8 RID: 17352
	public Transform KunLeftHandRing2;

	// Token: 0x040043C9 RID: 17353
	public Transform KunLeftHandRing3;

	// Token: 0x040043CA RID: 17354
	public Transform KunLeftHandMiddle1;

	// Token: 0x040043CB RID: 17355
	public Transform KunLeftHandMiddle2;

	// Token: 0x040043CC RID: 17356
	public Transform KunLeftHandMiddle3;

	// Token: 0x040043CD RID: 17357
	public Transform KunLeftHandIndex1;

	// Token: 0x040043CE RID: 17358
	public Transform KunLeftHandIndex2;

	// Token: 0x040043CF RID: 17359
	public Transform KunLeftHandIndex3;

	// Token: 0x040043D0 RID: 17360
	public Transform KunLeftHandThumb1;

	// Token: 0x040043D1 RID: 17361
	public Transform KunLeftHandThumb2;

	// Token: 0x040043D2 RID: 17362
	public Transform KunLeftHandThumb3;

	// Token: 0x040043D3 RID: 17363
	public Transform KunRightHandPinky1;

	// Token: 0x040043D4 RID: 17364
	public Transform KunRightHandPinky2;

	// Token: 0x040043D5 RID: 17365
	public Transform KunRightHandPinky3;

	// Token: 0x040043D6 RID: 17366
	public Transform KunRightHandRing1;

	// Token: 0x040043D7 RID: 17367
	public Transform KunRightHandRing2;

	// Token: 0x040043D8 RID: 17368
	public Transform KunRightHandRing3;

	// Token: 0x040043D9 RID: 17369
	public Transform KunRightHandMiddle1;

	// Token: 0x040043DA RID: 17370
	public Transform KunRightHandMiddle2;

	// Token: 0x040043DB RID: 17371
	public Transform KunRightHandMiddle3;

	// Token: 0x040043DC RID: 17372
	public Transform KunRightHandIndex1;

	// Token: 0x040043DD RID: 17373
	public Transform KunRightHandIndex2;

	// Token: 0x040043DE RID: 17374
	public Transform KunRightHandIndex3;

	// Token: 0x040043DF RID: 17375
	public Transform KunRightHandThumb1;

	// Token: 0x040043E0 RID: 17376
	public Transform KunRightHandThumb2;

	// Token: 0x040043E1 RID: 17377
	public Transform KunRightHandThumb3;

	// Token: 0x040043E2 RID: 17378
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x040043E3 RID: 17379
	public SkinnedMeshRenderer SecondRenderer;

	// Token: 0x040043E4 RID: 17380
	public SkinnedMeshRenderer ThirdRenderer;

	// Token: 0x040043E5 RID: 17381
	public bool Kizuna;

	// Token: 0x040043E6 RID: 17382
	public bool Man;

	// Token: 0x040043E7 RID: 17383
	public int ID;

	// Token: 0x040043E8 RID: 17384
	private bool Adjusted;
}
