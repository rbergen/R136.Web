﻿using R136.Entities.Global;
using R136.Interfaces;

namespace R136.Entities.Animates
{
	class Plant : StrikableAnimate
	{
		public static Animate Create(Initializer initializer)
			=> new Plant(initializer.ID, initializer.StartRoom, initializer.StrikeCount);

		private Plant(AnimateID id, RoomID startRoom, int strikeCount) : base(id, startRoom, strikeCount) { }

		protected override void ProgressStatusInternal(AnimateStatus status)
		{
			switch (status)
			{
				case AnimateStatus.Initial:
				case AnimateStatus.Attack:
					if (status == AnimateStatus.Initial && Facilities.Configuration.FreezeAnimates)
						break;

					Player?.DecreaseHealth();

					Status = Facilities.Randomizer.Next(2) == 0
						? AnimateStatus.PreparingNextAttack
						: AnimateStatus.Attack;

					break;

				case AnimateStatus.PreparingNextAttack:
					Status = AnimateStatus.Attack;

					break;

				case AnimateStatus.Dying:
					StatusManager?.OpenConnection(Direction.North, RoomID.SlimeCave);
					Status = AnimateStatus.Done;

					break;
			}
		}
	}
}
