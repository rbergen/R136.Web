﻿using R136.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R136.Entities.Animates
{
	public class Mist : Animate
	{
		public static StatusTextMapper? StatusTexts { get; set; }

		public Mist(IServiceProvider serviceProvider, RoomID startRoom) : base(serviceProvider, startRoom, StatusTexts) { }

		public override void ProcessStatusInternal(AnimateStatus status)
		{
			if (StatusManager != null)
			{
				switch (Randomizer.Next(3))
				{
					case 0:
						StatusManager.CurrentRoom = RoomID.StormCave;
						break;
					case 1:
						StatusManager.CurrentRoom = RoomID.SmallCave;
						break;
					case 2:
						StatusManager.CurrentRoom = RoomID.SpiralstaircaseCave1;
						break;
				}
			}
		}
	}
}
