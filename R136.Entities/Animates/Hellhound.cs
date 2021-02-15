﻿using R136.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R136.Entities.Animates
{
	public class HellHound : StrikableAnimate
	{

		public static StatusTextMapper? StatusTexts { get; set; }

		public HellHound(IServiceProvider serviceProvider, RoomID startRoom, int strikeCount) : base(serviceProvider, startRoom, strikeCount, StatusTexts) { }

		public override void ProcessStatusInternal(AnimateStatus status)
		{
			switch (status)
			{
				case AnimateStatus.Initial:
					Status = AnimateStatus.Attack;

					break;

				case AnimateStatus.Attack:
					StatusManager?.DecreaseHealth();
					Status = AnimateStatus.PreparingNextAttack;
					
					break;

				case AnimateStatus.PreparingNextAttack:
					if (Randomizer.Next(2) == 0)
						Status = AnimateStatus.Attack;

					break;

				case AnimateStatus.Dying:
					StatusManager?.ReleaseItem(ItemID.HoundMeat);
					Status = AnimateStatus.Done;

					break;
			}
		}
	}
}
