using System;
using UnityEngine;

// Token: 0x020004BF RID: 1215
public class YandereKunScript : MonoBehaviour
{
	// Token: 0x06001FC4 RID: 8132 RVA: 0x001C28C0 File Offset: 0x001C0AC0
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

	// Token: 0x06001FC5 RID: 8133 RVA: 0x001C2DA0 File Offset: 0x001C0FA0
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

	// Token: 0x040042C3 RID: 17091
	public Transform ChanItemParent;

	// Token: 0x040042C4 RID: 17092
	public Transform KunItemParent;

	// Token: 0x040042C5 RID: 17093
	public Transform ChanHips;

	// Token: 0x040042C6 RID: 17094
	public Transform ChanSpine;

	// Token: 0x040042C7 RID: 17095
	public Transform ChanSpine1;

	// Token: 0x040042C8 RID: 17096
	public Transform ChanSpine2;

	// Token: 0x040042C9 RID: 17097
	public Transform ChanSpine3;

	// Token: 0x040042CA RID: 17098
	public Transform ChanNeck;

	// Token: 0x040042CB RID: 17099
	public Transform ChanHead;

	// Token: 0x040042CC RID: 17100
	public Transform ChanRightUpLeg;

	// Token: 0x040042CD RID: 17101
	public Transform ChanRightLeg;

	// Token: 0x040042CE RID: 17102
	public Transform ChanRightFoot;

	// Token: 0x040042CF RID: 17103
	public Transform ChanRightToes;

	// Token: 0x040042D0 RID: 17104
	public Transform ChanLeftUpLeg;

	// Token: 0x040042D1 RID: 17105
	public Transform ChanLeftLeg;

	// Token: 0x040042D2 RID: 17106
	public Transform ChanLeftFoot;

	// Token: 0x040042D3 RID: 17107
	public Transform ChanLeftToes;

	// Token: 0x040042D4 RID: 17108
	public Transform ChanRightShoulder;

	// Token: 0x040042D5 RID: 17109
	public Transform ChanRightArm;

	// Token: 0x040042D6 RID: 17110
	public Transform ChanRightArmRoll;

	// Token: 0x040042D7 RID: 17111
	public Transform ChanRightForeArm;

	// Token: 0x040042D8 RID: 17112
	public Transform ChanRightForeArmRoll;

	// Token: 0x040042D9 RID: 17113
	public Transform ChanRightHand;

	// Token: 0x040042DA RID: 17114
	public Transform ChanLeftShoulder;

	// Token: 0x040042DB RID: 17115
	public Transform ChanLeftArm;

	// Token: 0x040042DC RID: 17116
	public Transform ChanLeftArmRoll;

	// Token: 0x040042DD RID: 17117
	public Transform ChanLeftForeArm;

	// Token: 0x040042DE RID: 17118
	public Transform ChanLeftForeArmRoll;

	// Token: 0x040042DF RID: 17119
	public Transform ChanLeftHand;

	// Token: 0x040042E0 RID: 17120
	public Transform ChanLeftHandPinky1;

	// Token: 0x040042E1 RID: 17121
	public Transform ChanLeftHandPinky2;

	// Token: 0x040042E2 RID: 17122
	public Transform ChanLeftHandPinky3;

	// Token: 0x040042E3 RID: 17123
	public Transform ChanLeftHandRing1;

	// Token: 0x040042E4 RID: 17124
	public Transform ChanLeftHandRing2;

	// Token: 0x040042E5 RID: 17125
	public Transform ChanLeftHandRing3;

	// Token: 0x040042E6 RID: 17126
	public Transform ChanLeftHandMiddle1;

	// Token: 0x040042E7 RID: 17127
	public Transform ChanLeftHandMiddle2;

	// Token: 0x040042E8 RID: 17128
	public Transform ChanLeftHandMiddle3;

	// Token: 0x040042E9 RID: 17129
	public Transform ChanLeftHandIndex1;

	// Token: 0x040042EA RID: 17130
	public Transform ChanLeftHandIndex2;

	// Token: 0x040042EB RID: 17131
	public Transform ChanLeftHandIndex3;

	// Token: 0x040042EC RID: 17132
	public Transform ChanLeftHandThumb1;

	// Token: 0x040042ED RID: 17133
	public Transform ChanLeftHandThumb2;

	// Token: 0x040042EE RID: 17134
	public Transform ChanLeftHandThumb3;

	// Token: 0x040042EF RID: 17135
	public Transform ChanRightHandPinky1;

	// Token: 0x040042F0 RID: 17136
	public Transform ChanRightHandPinky2;

	// Token: 0x040042F1 RID: 17137
	public Transform ChanRightHandPinky3;

	// Token: 0x040042F2 RID: 17138
	public Transform ChanRightHandRing1;

	// Token: 0x040042F3 RID: 17139
	public Transform ChanRightHandRing2;

	// Token: 0x040042F4 RID: 17140
	public Transform ChanRightHandRing3;

	// Token: 0x040042F5 RID: 17141
	public Transform ChanRightHandMiddle1;

	// Token: 0x040042F6 RID: 17142
	public Transform ChanRightHandMiddle2;

	// Token: 0x040042F7 RID: 17143
	public Transform ChanRightHandMiddle3;

	// Token: 0x040042F8 RID: 17144
	public Transform ChanRightHandIndex1;

	// Token: 0x040042F9 RID: 17145
	public Transform ChanRightHandIndex2;

	// Token: 0x040042FA RID: 17146
	public Transform ChanRightHandIndex3;

	// Token: 0x040042FB RID: 17147
	public Transform ChanRightHandThumb1;

	// Token: 0x040042FC RID: 17148
	public Transform ChanRightHandThumb2;

	// Token: 0x040042FD RID: 17149
	public Transform ChanRightHandThumb3;

	// Token: 0x040042FE RID: 17150
	public Transform KunHips;

	// Token: 0x040042FF RID: 17151
	public Transform KunSpine;

	// Token: 0x04004300 RID: 17152
	public Transform KunSpine1;

	// Token: 0x04004301 RID: 17153
	public Transform KunSpine2;

	// Token: 0x04004302 RID: 17154
	public Transform KunSpine3;

	// Token: 0x04004303 RID: 17155
	public Transform KunNeck;

	// Token: 0x04004304 RID: 17156
	public Transform KunHead;

	// Token: 0x04004305 RID: 17157
	public Transform KunRightUpLeg;

	// Token: 0x04004306 RID: 17158
	public Transform KunRightLeg;

	// Token: 0x04004307 RID: 17159
	public Transform KunRightFoot;

	// Token: 0x04004308 RID: 17160
	public Transform KunRightToes;

	// Token: 0x04004309 RID: 17161
	public Transform KunLeftUpLeg;

	// Token: 0x0400430A RID: 17162
	public Transform KunLeftLeg;

	// Token: 0x0400430B RID: 17163
	public Transform KunLeftFoot;

	// Token: 0x0400430C RID: 17164
	public Transform KunLeftToes;

	// Token: 0x0400430D RID: 17165
	public Transform KunRightShoulder;

	// Token: 0x0400430E RID: 17166
	public Transform KunRightArm;

	// Token: 0x0400430F RID: 17167
	public Transform KunRightArmRoll;

	// Token: 0x04004310 RID: 17168
	public Transform KunRightForeArm;

	// Token: 0x04004311 RID: 17169
	public Transform KunRightForeArmRoll;

	// Token: 0x04004312 RID: 17170
	public Transform KunRightHand;

	// Token: 0x04004313 RID: 17171
	public Transform KunLeftShoulder;

	// Token: 0x04004314 RID: 17172
	public Transform KunLeftArm;

	// Token: 0x04004315 RID: 17173
	public Transform KunLeftArmRoll;

	// Token: 0x04004316 RID: 17174
	public Transform KunLeftForeArm;

	// Token: 0x04004317 RID: 17175
	public Transform KunLeftForeArmRoll;

	// Token: 0x04004318 RID: 17176
	public Transform KunLeftHand;

	// Token: 0x04004319 RID: 17177
	public Transform KunLeftHandPinky1;

	// Token: 0x0400431A RID: 17178
	public Transform KunLeftHandPinky2;

	// Token: 0x0400431B RID: 17179
	public Transform KunLeftHandPinky3;

	// Token: 0x0400431C RID: 17180
	public Transform KunLeftHandRing1;

	// Token: 0x0400431D RID: 17181
	public Transform KunLeftHandRing2;

	// Token: 0x0400431E RID: 17182
	public Transform KunLeftHandRing3;

	// Token: 0x0400431F RID: 17183
	public Transform KunLeftHandMiddle1;

	// Token: 0x04004320 RID: 17184
	public Transform KunLeftHandMiddle2;

	// Token: 0x04004321 RID: 17185
	public Transform KunLeftHandMiddle3;

	// Token: 0x04004322 RID: 17186
	public Transform KunLeftHandIndex1;

	// Token: 0x04004323 RID: 17187
	public Transform KunLeftHandIndex2;

	// Token: 0x04004324 RID: 17188
	public Transform KunLeftHandIndex3;

	// Token: 0x04004325 RID: 17189
	public Transform KunLeftHandThumb1;

	// Token: 0x04004326 RID: 17190
	public Transform KunLeftHandThumb2;

	// Token: 0x04004327 RID: 17191
	public Transform KunLeftHandThumb3;

	// Token: 0x04004328 RID: 17192
	public Transform KunRightHandPinky1;

	// Token: 0x04004329 RID: 17193
	public Transform KunRightHandPinky2;

	// Token: 0x0400432A RID: 17194
	public Transform KunRightHandPinky3;

	// Token: 0x0400432B RID: 17195
	public Transform KunRightHandRing1;

	// Token: 0x0400432C RID: 17196
	public Transform KunRightHandRing2;

	// Token: 0x0400432D RID: 17197
	public Transform KunRightHandRing3;

	// Token: 0x0400432E RID: 17198
	public Transform KunRightHandMiddle1;

	// Token: 0x0400432F RID: 17199
	public Transform KunRightHandMiddle2;

	// Token: 0x04004330 RID: 17200
	public Transform KunRightHandMiddle3;

	// Token: 0x04004331 RID: 17201
	public Transform KunRightHandIndex1;

	// Token: 0x04004332 RID: 17202
	public Transform KunRightHandIndex2;

	// Token: 0x04004333 RID: 17203
	public Transform KunRightHandIndex3;

	// Token: 0x04004334 RID: 17204
	public Transform KunRightHandThumb1;

	// Token: 0x04004335 RID: 17205
	public Transform KunRightHandThumb2;

	// Token: 0x04004336 RID: 17206
	public Transform KunRightHandThumb3;

	// Token: 0x04004337 RID: 17207
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04004338 RID: 17208
	public SkinnedMeshRenderer SecondRenderer;

	// Token: 0x04004339 RID: 17209
	public SkinnedMeshRenderer ThirdRenderer;

	// Token: 0x0400433A RID: 17210
	public bool Kizuna;

	// Token: 0x0400433B RID: 17211
	public bool Man;

	// Token: 0x0400433C RID: 17212
	public int ID;

	// Token: 0x0400433D RID: 17213
	private bool Adjusted;
}
