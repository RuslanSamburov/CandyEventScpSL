using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Items;
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
        public void StartCandyEvent(int interval, int countCandy)
        {
            Plugin.Singleton._candyCoroutine = Timing.RunCoroutine(CandyGivingCoroutine(interval, countCandy));
        }

        public void StopCandyEvent()
        {
            Timing.KillCoroutines(Plugin.Singleton._candyCoroutine);
        }

        private IEnumerator<float> CandyGivingCoroutine(int interval, int countCandy)
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(interval);

                foreach (Player player in Player.List.Where(x => x.IsHuman))
                {
                    for (int i = 0; i < countCandy; i++)
                    {
                        player.TryAddCandy(_candys.GetRandomValue());
                        yield return Timing.WaitForSeconds(.1f);
                    }
                }
            }
        }
    }
}
