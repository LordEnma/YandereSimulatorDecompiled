using UnityEngine;

public class FollowSkirtScript : MonoBehaviour
{
	public Transform[] TargetSkirtFront;

	public Transform[] TargetSkirtBack;

	public Transform[] TargetSkirtRight;

	public Transform[] TargetSkirtLeft;

	public Transform[] SkirtFront;

	public Transform[] SkirtBack;

	public Transform[] SkirtRight;

	public Transform[] SkirtLeft;

	public Transform TargetSkirtHips;

	public Transform SkirtHips;

	private void LateUpdate()
	{
		SkirtHips.position = TargetSkirtHips.position;
		for (int i = 0; i < 3; i++)
		{
			SkirtFront[i].position = TargetSkirtFront[i].position;
			SkirtFront[i].rotation = TargetSkirtFront[i].rotation;
			SkirtBack[i].position = TargetSkirtBack[i].position;
			SkirtBack[i].rotation = TargetSkirtBack[i].rotation;
			SkirtRight[i].position = TargetSkirtRight[i].position;
			SkirtRight[i].rotation = TargetSkirtRight[i].rotation;
			SkirtLeft[i].position = TargetSkirtLeft[i].position;
			SkirtLeft[i].rotation = TargetSkirtLeft[i].rotation;
		}
	}
}
