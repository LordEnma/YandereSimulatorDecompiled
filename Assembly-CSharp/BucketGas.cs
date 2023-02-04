using System;

[Serializable]
public class BucketGas : BucketContents
{
	public override BucketContentsType Type => BucketContentsType.Gas;

	public override bool IsCleaningAgent => false;

	public override bool IsFlammable => true;

	public override bool CanBeLifted(int strength)
	{
		return true;
	}
}
