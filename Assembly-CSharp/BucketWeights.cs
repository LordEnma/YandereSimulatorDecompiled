using System;
using UnityEngine;

[Serializable]
public class BucketWeights : BucketContents
{
	[SerializeField]
	private int count;

	public int Count
	{
		get
		{
			return count;
		}
		set
		{
			count = ((value >= 0) ? value : 0);
		}
	}

	public override BucketContentsType Type => BucketContentsType.Weights;

	public override bool IsCleaningAgent => false;

	public override bool IsFlammable => false;

	public override bool CanBeLifted(int strength)
	{
		return strength > 0;
	}
}
