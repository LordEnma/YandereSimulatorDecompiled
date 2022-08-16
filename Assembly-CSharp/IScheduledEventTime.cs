// Decompiled with JetBrains decompiler
// Type: IScheduledEventTime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

public interface IScheduledEventTime
{
  ScheduledEventTimeType ScheduleType { get; }

  bool OccurringNow(DateAndTime currentTime);

  bool OccursInTheFuture(DateAndTime currentTime);

  bool OccurredInThePast(DateAndTime currentTime);
}
