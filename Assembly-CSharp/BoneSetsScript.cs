using UnityEngine;

public class BoneSetsScript : MonoBehaviour
{
	public Transform[] BoneSet1;

	public Transform[] BoneSet2;

	public Transform[] BoneSet3;

	public Transform[] BoneSet4;

	public Transform[] BoneSet5;

	public Transform[] BoneSet6;

	public Transform[] BoneSet7;

	public Transform[] BoneSet8;

	public Transform[] BoneSet9;

	public Vector3[] BoneSet1Pos;

	public Vector3[] BoneSet2Pos;

	public Vector3[] BoneSet3Pos;

	public Vector3[] BoneSet4Pos;

	public Vector3[] BoneSet5Pos;

	public Vector3[] BoneSet6Pos;

	public Vector3[] BoneSet7Pos;

	public Vector3[] BoneSet8Pos;

	public Vector3[] BoneSet9Pos;

	public float Timer;

	public Transform RightArm;

	public Transform LeftArm;

	public Transform RightLeg;

	public Transform LeftLeg;

	public Transform Head;

	public Vector3 RightArmPosition;

	public Vector3 RightArmRotation;

	public Vector3 LeftArmPosition;

	public Vector3 LeftArmRotation;

	public Vector3 RightLegPosition;

	public Vector3 RightLegRotation;

	public Vector3 LeftLegPosition;

	public Vector3 LeftLegRotation;

	public Vector3 HeadPosition;

	private void Start()
	{
	}

	private void Update()
	{
		if (Head != null)
		{
			RightArm.localPosition = RightArmPosition;
			RightArm.localEulerAngles = RightArmRotation;
			LeftArm.localPosition = LeftArmPosition;
			LeftArm.localEulerAngles = LeftArmRotation;
			RightLeg.localPosition = RightLegPosition;
			RightLeg.localEulerAngles = RightLegRotation;
			LeftLeg.localPosition = LeftLegPosition;
			LeftLeg.localEulerAngles = LeftLegRotation;
			Head.localPosition = HeadPosition;
		}
		base.enabled = false;
	}
}
