using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Radio_Blue_Point.Views
{
    public static class ShadowEffect
    {
        public static readonly BindableProperty HasShadowProperty =
          BindableProperty.CreateAttached("HasShadow", typeof(bool), typeof(ShadowEffect), false, propertyChanged: OnHasShadowChanged);
        public static readonly BindableProperty ColorProperty =
          BindableProperty.CreateAttached("Color", typeof(Color), typeof(ShadowEffect), Color.Default);
        public static readonly BindableProperty RadiusProperty =
          BindableProperty.CreateAttached("Radius", typeof(double), typeof(ShadowEffect), 1.0);
        public static readonly BindableProperty DistanceXProperty =
          BindableProperty.CreateAttached("DistanceX", typeof(double), typeof(ShadowEffect), 0.0);
        public static readonly BindableProperty DistanceYProperty =
          BindableProperty.CreateAttached("DistanceY", typeof(double), typeof(ShadowEffect), 0.0);

        public static bool GetHasShadow(BindableObject view)
        {
            return (bool)view.GetValue(HasShadowProperty);
        }
        public static void SetHasShadow(BindableObject view, bool value)
        {
            view.SetValue(HasShadowProperty, value);
        }

        public static double GetRadiusProperty(BindableObject view)
        {
            return (double)view.GetValue(RadiusProperty);
        }
        public static void SetRadiusProperty(BindableObject view, double value)
        {
            view.SetValue(RadiusProperty, value);
        }

        public static Color GetColorProperty(BindableObject view)
        {
            return (Color)view.GetValue(ColorProperty);
        }
        public static void SetColorProperty(BindableObject view, Color value)
        {
            view.SetValue(ColorProperty, value);
        }

        public static double GetDistanceYProperty(BindableObject view)
        {
            return (double)view.GetValue(DistanceXProperty);
        }
        public static void SetDistanceYProperty(BindableObject view, double value)
        {
            view.SetValue(DistanceXProperty, value);
        }


        public static double GetDistanceXProperty(BindableObject view)
        {
            return (double)view.GetValue(DistanceYProperty);
        }
        public static void SetDistanceXProperty(BindableObject view, double value)
        {
            view.SetValue(DistanceYProperty, value);
        }






        static void OnHasShadowChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;
            if (view == null)
            {
                return;
            }

            bool hasShadow = (bool)newValue;
            if (hasShadow)
            {
                view.Effects.Add(new LabelShadowEffect());
            }
            else
            {
                var toRemove = view.Effects.FirstOrDefault(e => e is LabelShadowEffect);
                if (toRemove != null)
                {
                    view.Effects.Remove(toRemove);
                }
            }
        }

        class LabelShadowEffect : RoutingEffect
        {
            public LabelShadowEffect() : base("MyCompany.LabelShadowEffect")
            {
            }
        }


        // COME USARLA   --> problema con local:ShadowEffect.RadiusProperty="5" e gli altri...
        /* 
        <Label Text = "Label Shadow Effect"
       local:ShadowEffect.HasShadow="true" local:ShadowEffect.RadiusProperty="5"
       local:ShadowEffect.DistanceXProperty="5" local:ShadowEffect.DistanceYProperty="5">
            <local:ShadowEffect.ColorProperty>
                <OnPlatform x:TypeArguments="Color">
                    <On Platform = "iOS" Value="Black" />
                    <On Platform = "Android" Value="White" />
                    <On Platform = "UWP" Value="Red" />
                </OnPlatform>
            </local:ShadowEffect.ColorProperty>
        </Label>
        */

    }
}
