using System;
using UnityEngine;

[Serializable]
public class CharacterSkeleton
{
	[SerializeField]
	private Transform head;

	[SerializeField]
	private Transform neck;

	[SerializeField]
	private Transform chest;

	[SerializeField]
	private Transform stomach;

	[SerializeField]
	private Transform pelvis;

	[SerializeField]
	private Transform rightShoulder;

	[SerializeField]
	private Transform leftShoulder;

	[SerializeField]
	private Transform rightUpperArm;

	[SerializeField]
	private Transform leftUpperArm;

	[SerializeField]
	private Transform rightElbow;

	[SerializeField]
	private Transform leftElbow;

	[SerializeField]
	private Transform rightLowerArm;

	[SerializeField]
	private Transform leftLowerArm;

	[SerializeField]
	private Transform rightPalm;

	[SerializeField]
	private Transform leftPalm;

	[SerializeField]
	private Transform rightUpperLeg;

	[SerializeField]
	private Transform leftUpperLeg;

	[SerializeField]
	private Transform rightKnee;

	[SerializeField]
	private Transform leftKnee;

	[SerializeField]
	private Transform rightLowerLeg;

	[SerializeField]
	private Transform leftLowerLeg;

	[SerializeField]
	private Transform rightFoot;

	[SerializeField]
	private Transform leftFoot;

	public Transform Head => head;

	public Transform Neck => neck;

	public Transform Chest => chest;

	public Transform Stomach => stomach;

	public Transform Pelvis => pelvis;

	public Transform RightShoulder => rightShoulder;

	public Transform LeftShoulder => leftShoulder;

	public Transform RightUpperArm => rightUpperArm;

	public Transform LeftUpperArm => leftUpperArm;

	public Transform RightElbow => rightElbow;

	public Transform LeftElbow => leftElbow;

	public Transform RightLowerArm => rightLowerArm;

	public Transform LeftLowerArm => leftLowerArm;

	public Transform RightPalm => rightPalm;

	public Transform LeftPalm => leftPalm;

	public Transform RightUpperLeg => rightUpperLeg;

	public Transform LeftUpperLeg => leftUpperLeg;

	public Transform RightKnee => rightKnee;

	public Transform LeftKnee => leftKnee;

	public Transform RightLowerLeg => rightLowerLeg;

	public Transform LeftLowerLeg => leftLowerLeg;

	public Transform RightFoot => rightFoot;

	public Transform LeftFoot => leftFoot;
}
