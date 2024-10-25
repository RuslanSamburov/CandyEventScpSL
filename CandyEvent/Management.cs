using Exiled.API.Extensions;
using Exiled.API.Features;
using InventorySystem.Items.Usables.Scp330;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyEvent.Commands
{
    public class Management
    {
        List<CandyKindID> _candys = Enum.GetValues(typeof(CandyKindID)).Cast<CandyKindID>().Where(candy => candy != CandyKindID.None).ToList();
        public void StartCandyEvent(int? interval = null)
        {
            int timeInterval = interval ?? Plugin.Singleton.Config.CandyInterval;
            Plugin.Singleton._candyCoroutine = Timing.RunCoroutine(CandyGivingCoroutine(timeInterval));
        }

        public void StopCandyEvent()
        {
            Timing.KillCoroutines(Plugin.Singleton._candyCoroutine);
        }

        private IEnumerator<float> CandyGivingCoroutine(int interval)
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(interval);

                foreach (var player in Player.List.Where(x => x.IsHuman))
                {
                    player.TryAddCandy(_candys.GetRandomValue());
                }
            }
        }
    }
}
