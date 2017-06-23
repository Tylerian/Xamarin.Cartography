﻿using UIKit;

namespace Cartography
{
    public static partial class Extensions
    {
		public static LayoutSupport TopLayoutGuideCartography(this UIViewController instance)
        {
            return new LayoutSupport(instance.TopLayoutGuide as UILayoutSupport, NSLayoutAttribute.Top);
        }

		public static LayoutSupport BottomLayoutGuideCartography(this UIViewController instance)
        {
            return new LayoutSupport(instance.TopLayoutGuide as UILayoutSupport, NSLayoutAttribute.Bottom);
        }
    }
}
