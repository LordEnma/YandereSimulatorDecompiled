using System;

// Token: 0x02000493 RID: 1171
public static class CardinalDirection
{
	// Token: 0x06001F22 RID: 7970 RVA: 0x001B83C0 File Offset: 0x001B65C0
	public static Direction Reversed(Direction direction)
	{
		if (direction == Direction.North)
		{
			return Direction.South;
		}
		if (direction == Direction.East)
		{
			return Direction.West;
		}
		if (direction == Direction.South)
		{
			return Direction.North;
		}
		return Direction.East;
	}

	// Token: 0x06001F23 RID: 7971 RVA: 0x001B83D4 File Offset: 0x001B65D4
	public static Direction LeftPerp(Direction direction)
	{
		if (direction == Direction.North)
		{
			return Direction.West;
		}
		if (direction == Direction.East)
		{
			return Direction.North;
		}
		if (direction == Direction.South)
		{
			return Direction.East;
		}
		return Direction.South;
	}

	// Token: 0x06001F24 RID: 7972 RVA: 0x001B83E8 File Offset: 0x001B65E8
	public static Direction RightPerp(Direction direction)
	{
		if (direction == Direction.North)
		{
			return Direction.East;
		}
		if (direction == Direction.East)
		{
			return Direction.South;
		}
		if (direction == Direction.South)
		{
			return Direction.West;
		}
		return Direction.North;
	}
}
