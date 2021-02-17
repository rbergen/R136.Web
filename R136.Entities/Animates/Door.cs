﻿using R136.Entities.General;

namespace R136.Entities.Animates
{
	class Door : Animate
	{
		public Door(AnimateID id, RoomID startRoom) : base(id, startRoom) { }

		protected override void ProgressStatusInternal(AnimateStatus status)
		{
			if (status == AnimateStatus.Operating)
			{
				StatusManager?.OpenConnection(Direction.North, RoomID.GarbageCave);
				Status = AnimateStatus.Done;
			}
		}

		public override Result Used(ItemID item)
		{
			if (item != ItemID.Bone)
				return Result.Error();

			Status = AnimateStatus.Operating;
			return Result.Success();
		}
	}
}
