﻿using R136.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R136.Entities.Animates
{
	public class Teleporter : Animate
	{
		public static StatusTextMapper? StatusTexts { get; set; }

		public Teleporter(IServiceProvider serviceProvider, RoomID startRoom) : base(serviceProvider, startRoom, StatusTexts) { }

		public override void ProcessStatusInternal(AnimateStatus status)
		{
			if (StatusManager != null)
			{
				StatusManager.CurrentRoom = RoomID.Forest1;
			}
		}
	}
}
