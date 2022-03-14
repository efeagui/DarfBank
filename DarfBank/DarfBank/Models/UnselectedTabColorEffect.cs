using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManagerUIDesign.Models
{
    public class UnselectedTabColorEffect : RoutingEffect
    {
        public UnselectedTabColorEffect()
            : base($"AppEffects.{nameof(UnselectedTabColorEffect)}")
        {
        }
    }
}