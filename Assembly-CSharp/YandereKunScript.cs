using UnityEngine;

public class YandereKunScript : MonoBehaviour
{
	public Transform ChanItemParent;

	public Transform KunItemParent;

	public Transform ChanHips;

	public Transform ChanSpine;

	public Transform ChanSpine1;

	public Transform ChanSpine2;

	public Transform ChanSpine3;

	public Transform ChanNeck;

	public Transform ChanHead;

	public Transform ChanRightUpLeg;

	public Transform ChanRightLeg;

	public Transform ChanRightFoot;

	public Transform ChanRightToes;

	public Transform ChanLeftUpLeg;

	public Transform ChanLeftLeg;

	public Transform ChanLeftFoot;

	public Transform ChanLeftToes;

	public Transform ChanRightShoulder;

	public Transform ChanRightArm;

	public Transform ChanRightArmRoll;

	public Transform ChanRightForeArm;

	public Transform ChanRightForeArmRoll;

	public Transform ChanRightHand;

	public Transform ChanLeftShoulder;

	public Transform ChanLeftArm;

	public Transform ChanLeftArmRoll;

	public Transform ChanLeftForeArm;

	public Transform ChanLeftForeArmRoll;

	public Transform ChanLeftHand;

	public Transform ChanLeftHandPinky1;

	public Transform ChanLeftHandPinky2;

	public Transform ChanLeftHandPinky3;

	public Transform ChanLeftHandRing1;

	public Transform ChanLeftHandRing2;

	public Transform ChanLeftHandRing3;

	public Transform ChanLeftHandMiddle1;

	public Transform ChanLeftHandMiddle2;

	public Transform ChanLeftHandMiddle3;

	public Transform ChanLeftHandIndex1;

	public Transform ChanLeftHandIndex2;

	public Transform ChanLeftHandIndex3;

	public Transform ChanLeftHandThumb1;

	public Transform ChanLeftHandThumb2;

	public Transform ChanLeftHandThumb3;

	public Transform ChanRightHandPinky1;

	public Transform ChanRightHandPinky2;

	public Transform ChanRightHandPinky3;

	public Transform ChanRightHandRing1;

	public Transform ChanRightHandRing2;

	public Transform ChanRightHandRing3;

	public Transform ChanRightHandMiddle1;

	public Transform ChanRightHandMiddle2;

	public Transform ChanRightHandMiddle3;

	public Transform ChanRightHandIndex1;

	public Transform ChanRightHandIndex2;

	public Transform ChanRightHandIndex3;

	public Transform ChanRightHandThumb1;

	public Transform ChanRightHandThumb2;

	public Transform ChanRightHandThumb3;

	public Transform KunHips;

	public Transform KunSpine;

	public Transform KunSpine1;

	public Transform KunSpine2;

	public Transform KunSpine3;

	public Transform KunNeck;

	public Transform KunHead;

	public Transform KunRightUpLeg;

	public Transform KunRightLeg;

	public Transform KunRightFoot;

	public Transform KunRightToes;

	public Transform KunLeftUpLeg;

	public Transform KunLeftLeg;

	public Transform KunLeftFoot;

	public Transform KunLeftToes;

	public Transform KunRightShoulder;

	public Transform KunRightArm;

	public Transform KunRightArmRoll;

	public Transform KunRightForeArm;

	public Transform KunRightForeArmRoll;

	public Transform KunRightHand;

	public Transform KunLeftShoulder;

	public Transform KunLeftArm;

	public Transform KunLeftArmRoll;

	public Transform KunLeftForeArm;

	public Transform KunLeftForeArmRoll;

	public Transform KunLeftHand;

	public Transform KunLeftHandPinky1;

	public Transform KunLeftHandPinky2;

	public Transform KunLeftHandPinky3;

	public Transform KunLeftHandRing1;

	public Transform KunLeftHandRing2;

	public Transform KunLeftHandRing3;

	public Transform KunLeftHandMiddle1;

	public Transform KunLeftHandMiddle2;

	public Transform KunLeftHandMiddle3;

	public Transform KunLeftHandIndex1;

	public Transform KunLeftHandIndex2;

	public Transform KunLeftHandIndex3;

	public Transform KunLeftHandThumb1;

	public Transform KunLeftHandThumb2;

	public Transform KunLeftHandThumb3;

	public Transform KunRightHandPinky1;

	public Transform KunRightHandPinky2;

	public Transform KunRightHandPinky3;

	public Transform KunRightHandRing1;

	public Transform KunRightHandRing2;

	public Transform KunRightHandRing3;

	public Transform KunRightHandMiddle1;

	public Transform KunRightHandMiddle2;

	public Transform KunRightHandMiddle3;

	public Transform KunRightHandIndex1;

	public Transform KunRightHandIndex2;

	public Transform KunRightHandIndex3;

	public Transform KunRightHandThumb1;

	public Transform KunRightHandThumb2;

	public Transform KunRightHandThumb3;

	public SkinnedMeshRenderer MyRenderer;

	public SkinnedMeshRenderer SecondRenderer;

	public SkinnedMeshRenderer ThirdRenderer;

	public bool Kizuna;

	public bool Man;

	public int ID;

	private bool Adjusted;

	private void Start()
	{
		if (!Kizuna)
		{
			if (KunHips != null)
			{
				KunHips.parent = ChanHips;
			}
			if (KunSpine != null)
			{
				KunSpine.parent = ChanSpine;
			}
			if (KunSpine1 != null)
			{
				KunSpine1.parent = ChanSpine1;
			}
			if (KunSpine2 != null)
			{
				KunSpine2.parent = ChanSpine2;
			}
			if (KunSpine3 != null)
			{
				KunSpine3.parent = ChanSpine3;
			}
			if (KunNeck != null)
			{
				KunNeck.parent = ChanNeck;
			}
			if (KunHead != null)
			{
				KunHead.parent = ChanHead;
			}
			KunRightUpLeg.parent = ChanRightUpLeg;
			KunRightLeg.parent = ChanRightLeg;
			KunRightFoot.parent = ChanRightFoot;
			KunRightToes.parent = ChanRightToes;
			KunLeftUpLeg.parent = ChanLeftUpLeg;
			KunLeftLeg.parent = ChanLeftLeg;
			KunLeftFoot.parent = ChanLeftFoot;
			KunLeftToes.parent = ChanLeftToes;
			KunRightShoulder.parent = ChanRightShoulder;
			KunRightArm.parent = ChanRightArm;
			if (KunRightArmRoll != null)
			{
				KunRightArmRoll.parent = ChanRightArmRoll;
			}
			KunRightForeArm.parent = ChanRightForeArm;
			if (KunRightForeArmRoll != null)
			{
				KunRightForeArmRoll.parent = ChanRightForeArmRoll;
			}
			KunRightHand.parent = ChanRightHand;
			KunLeftShoulder.parent = ChanLeftShoulder;
			KunLeftArm.parent = ChanLeftArm;
			if (KunLeftArmRoll != null)
			{
				KunLeftArmRoll.parent = ChanLeftArmRoll;
			}
			KunLeftForeArm.parent = ChanLeftForeArm;
			if (KunLeftForeArmRoll != null)
			{
				KunLeftForeArmRoll.parent = ChanLeftForeArmRoll;
			}
			KunLeftHand.parent = ChanLeftHand;
			if (!Man)
			{
				KunLeftHandPinky1.parent = ChanLeftHandPinky1;
				KunLeftHandPinky2.parent = ChanLeftHandPinky2;
				KunLeftHandPinky3.parent = ChanLeftHandPinky3;
				KunLeftHandRing1.parent = ChanLeftHandRing1;
				KunLeftHandRing2.parent = ChanLeftHandRing2;
				KunLeftHandRing3.parent = ChanLeftHandRing3;
				KunLeftHandMiddle1.parent = ChanLeftHandMiddle1;
				KunLeftHandMiddle2.parent = ChanLeftHandMiddle2;
				KunLeftHandMiddle3.parent = ChanLeftHandMiddle3;
				KunLeftHandIndex1.parent = ChanLeftHandIndex1;
				KunLeftHandIndex2.parent = ChanLeftHandIndex2;
				KunLeftHandIndex3.parent = ChanLeftHandIndex3;
				KunLeftHandThumb1.parent = ChanLeftHandThumb1;
				KunLeftHandThumb2.parent = ChanLeftHandThumb2;
				KunLeftHandThumb3.parent = ChanLeftHandThumb3;
				KunRightHandPinky1.parent = ChanRightHandPinky1;
				KunRightHandPinky2.parent = ChanRightHandPinky2;
				KunRightHandPinky3.parent = ChanRightHandPinky3;
				KunRightHandRing1.parent = ChanRightHandRing1;
				KunRightHandRing2.parent = ChanRightHandRing2;
				KunRightHandRing3.parent = ChanRightHandRing3;
				KunRightHandMiddle1.parent = ChanRightHandMiddle1;
				KunRightHandMiddle2.parent = ChanRightHandMiddle2;
				KunRightHandMiddle3.parent = ChanRightHandMiddle3;
				KunRightHandIndex1.parent = ChanRightHandIndex1;
				KunRightHandIndex2.parent = ChanRightHandIndex2;
				KunRightHandIndex3.parent = ChanRightHandIndex3;
				KunRightHandThumb1.parent = ChanRightHandThumb1;
				KunRightHandThumb2.parent = ChanRightHandThumb2;
				KunRightHandThumb3.parent = ChanRightHandThumb3;
			}
		}
		if (MyRenderer != null)
		{
			MyRenderer.enabled = true;
		}
		if (SecondRenderer != null)
		{
			SecondRenderer.enabled = true;
		}
		if (ThirdRenderer != null)
		{
			ThirdRenderer.enabled = true;
		}
		base.gameObject.SetActive(value: false);
	}

	private void LateUpdate()
	{
		if (Man)
		{
			ChanItemParent.position = KunItemParent.position;
			if (!Adjusted)
			{
				KunRightShoulder.position += new Vector3(0f, 0.1f, 0f);
				KunRightArm.position += new Vector3(0f, 0.1f, 0f);
				KunRightForeArm.position += new Vector3(0f, 0.1f, 0f);
				KunRightHand.position += new Vector3(0f, 0.1f, 0f);
				KunLeftShoulder.position += new Vector3(0f, 0.1f, 0f);
				KunLeftArm.position += new Vector3(0f, 0.1f, 0f);
				KunLeftForeArm.position += new Vector3(0f, 0.1f, 0f);
				KunLeftHand.position += new Vector3(0f, 0.1f, 0f);
				Adjusted = true;
			}
		}
		if (!Kizuna)
		{
			return;
		}
		KunItemParent.localPosition = new Vector3(0.066666f, -0.033333f, 0.02f);
		ChanItemParent.position = KunItemParent.position;
		KunHips.localPosition = ChanHips.localPosition;
		if (KunHips != null)
		{
			KunHips.eulerAngles = ChanHips.eulerAngles;
		}
		if (KunSpine != null)
		{
			KunSpine.eulerAngles = ChanSpine.eulerAngles;
		}
		if (KunSpine1 != null)
		{
			KunSpine1.eulerAngles = ChanSpine1.eulerAngles;
		}
		if (KunSpine2 != null)
		{
			KunSpine2.eulerAngles = ChanSpine2.eulerAngles;
		}
		if (KunSpine3 != null)
		{
			KunSpine3.eulerAngles = ChanSpine3.eulerAngles;
		}
		if (KunNeck != null)
		{
			KunNeck.eulerAngles = ChanNeck.eulerAngles;
		}
		if (KunHead != null)
		{
			KunHead.eulerAngles = ChanHead.eulerAngles;
		}
		KunRightUpLeg.eulerAngles = ChanRightUpLeg.eulerAngles;
		KunRightLeg.eulerAngles = ChanRightLeg.eulerAngles;
		KunRightFoot.eulerAngles = ChanRightFoot.eulerAngles;
		KunRightToes.eulerAngles = ChanRightToes.eulerAngles;
		KunLeftUpLeg.eulerAngles = ChanLeftUpLeg.eulerAngles;
		KunLeftLeg.eulerAngles = ChanLeftLeg.eulerAngles;
		KunLeftFoot.eulerAngles = ChanLeftFoot.eulerAngles;
		KunLeftToes.eulerAngles = ChanLeftToes.eulerAngles;
		KunRightShoulder.eulerAngles = ChanRightShoulder.eulerAngles;
		KunRightArm.eulerAngles = ChanRightArm.eulerAngles;
		if (KunLeftArmRoll != null)
		{
			KunRightArmRoll.eulerAngles = ChanRightArmRoll.eulerAngles;
		}
		KunRightForeArm.eulerAngles = ChanRightForeArm.eulerAngles;
		if (KunLeftArmRoll != null)
		{
			KunRightForeArmRoll.eulerAngles = ChanRightForeArmRoll.eulerAngles;
		}
		KunRightHand.eulerAngles = ChanRightHand.eulerAngles;
		KunLeftShoulder.eulerAngles = ChanLeftShoulder.eulerAngles;
		KunLeftArm.eulerAngles = ChanLeftArm.eulerAngles;
		if (KunLeftArmRoll != null)
		{
			KunLeftArmRoll.eulerAngles = ChanLeftArmRoll.eulerAngles;
		}
		KunLeftForeArm.eulerAngles = ChanLeftForeArm.eulerAngles;
		if (KunLeftForeArmRoll != null)
		{
			KunLeftForeArmRoll.eulerAngles = ChanLeftForeArmRoll.eulerAngles;
		}
		KunLeftHand.eulerAngles = ChanLeftHand.eulerAngles;
		KunLeftHandPinky1.eulerAngles = ChanLeftHandPinky1.eulerAngles;
		KunLeftHandPinky2.eulerAngles = ChanLeftHandPinky2.eulerAngles;
		KunLeftHandPinky3.eulerAngles = ChanLeftHandPinky3.eulerAngles;
		KunLeftHandRing1.eulerAngles = ChanLeftHandRing1.eulerAngles;
		KunLeftHandRing2.eulerAngles = ChanLeftHandRing2.eulerAngles;
		KunLeftHandRing3.eulerAngles = ChanLeftHandRing3.eulerAngles;
		KunLeftHandMiddle1.eulerAngles = ChanLeftHandMiddle1.eulerAngles;
		KunLeftHandMiddle2.eulerAngles = ChanLeftHandMiddle2.eulerAngles;
		KunLeftHandMiddle3.eulerAngles = ChanLeftHandMiddle3.eulerAngles;
		KunLeftHandIndex1.eulerAngles = ChanLeftHandIndex1.eulerAngles;
		KunLeftHandIndex2.eulerAngles = ChanLeftHandIndex2.eulerAngles;
		KunLeftHandIndex3.eulerAngles = ChanLeftHandIndex3.eulerAngles;
		KunLeftHandThumb1.eulerAngles = ChanLeftHandThumb1.eulerAngles;
		KunLeftHandThumb2.eulerAngles = ChanLeftHandThumb2.eulerAngles;
		KunLeftHandThumb3.eulerAngles = ChanLeftHandThumb3.eulerAngles;
		KunRightHandPinky1.eulerAngles = ChanRightHandPinky1.eulerAngles;
		KunRightHandPinky2.eulerAngles = ChanRightHandPinky2.eulerAngles;
		KunRightHandPinky3.eulerAngles = ChanRightHandPinky3.eulerAngles;
		KunRightHandRing1.eulerAngles = ChanRightHandRing1.eulerAngles;
		KunRightHandRing2.eulerAngles = ChanRightHandRing2.eulerAngles;
		KunRightHandRing3.eulerAngles = ChanRightHandRing3.eulerAngles;
		KunRightHandMiddle1.eulerAngles = ChanRightHandMiddle1.eulerAngles;
		KunRightHandMiddle2.eulerAngles = ChanRightHandMiddle2.eulerAngles;
		KunRightHandMiddle3.eulerAngles = ChanRightHandMiddle3.eulerAngles;
		KunRightHandIndex1.eulerAngles = ChanRightHandIndex1.eulerAngles;
		KunRightHandIndex2.eulerAngles = ChanRightHandIndex2.eulerAngles;
		KunRightHandIndex3.eulerAngles = ChanRightHandIndex3.eulerAngles;
		KunRightHandThumb1.eulerAngles = ChanRightHandThumb1.eulerAngles;
		KunRightHandThumb2.eulerAngles = ChanRightHandThumb2.eulerAngles;
		KunRightHandThumb3.eulerAngles = ChanRightHandThumb3.eulerAngles;
		if (!Input.GetKeyDown(KeyCode.Space))
		{
			return;
		}
		if (ID > -1)
		{
			for (int i = 0; i < 32; i++)
			{
				SecondRenderer.SetBlendShapeWeight(i, 0f);
			}
			if (ID > 32)
			{
				ID = 0;
			}
			SecondRenderer.SetBlendShapeWeight(ID, 100f);
		}
		ID++;
	}
}
