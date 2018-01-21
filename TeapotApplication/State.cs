using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeapotApplication
{
    public class State
    {
        public enum TeapotState
        {
            Whistling,
            NotWhistling,
            BoilingOver
        }

        public static Dictionary<Tuple<TeapotState, TeapotState>, string> EnumToStringDictionary =
            new Dictionary<Tuple<TeapotState, TeapotState>, string> {
                   [Tuple.Create(TeapotState.Whistling, TeapotState.Whistling)]  = "All your teapots are whistling!  Throw a neighborhood tea party ASAP.",
                   [Tuple.Create(TeapotState.Whistling, TeapotState.BoilingOver)]  = "One teapot is ready and one teapot is TOO ready, so get over to the stove, turn it down, and make some tea.",
                   [Tuple.Create(TeapotState.Whistling, TeapotState.NotWhistling)]  = "You have enough hot water for a couple people.  Keep up the good work of turning cold water into hot water.",
                   [Tuple.Create(TeapotState.BoilingOver, TeapotState.BoilingOver)]  = "AAAAAHH all your teapots are boiling over!!  :O  Pay some attention to your tea friend!",
                   [Tuple.Create(TeapotState.BoilingOver, TeapotState.Whistling)]  = "One teapot is ready and one teapot is TOO ready, so get over to the stove, turn it down, and make some tea.",
                   [Tuple.Create(TeapotState.BoilingOver, TeapotState.NotWhistling)]  = "One teapot is too hot and the other one isn't hot enough.  Maybe try switching burners?",
                   [Tuple.Create(TeapotState.NotWhistling, TeapotState.NotWhistling)]  = "No whistling teapots??  Turn up the stove, buy some tea, and enjoy life a bit!",
                   [Tuple.Create(TeapotState.NotWhistling, TeapotState.BoilingOver)]  = "One teapot is too hot and the other one isn't hot enough.  Maybe try switching burners?",
                   [Tuple.Create(TeapotState.NotWhistling, TeapotState.Whistling)]  = "You have enough hot water for a couple people.  Keep up the good work of turning cold water into hot water."
            };
    }
}
