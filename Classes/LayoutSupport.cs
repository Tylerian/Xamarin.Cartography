using System;

using UIKit;

namespace Cartography
{
    public class LayoutSupport
    {
        public UILayoutSupport LayoutGuide { get; }
        public NSLayoutAttribute Attribute { get; }

        public LayoutSupport(UILayoutSupport layoutGuide, NSLayoutAttribute layoutAttribute)
        {
            LayoutGuide = layoutGuide;
            Attribute = layoutAttribute;
        }

        public static LayoutSupportExpression operator +(LayoutSupport lhs, nfloat c)
        {
            return new LayoutSupportExpression(lhs, new[] { new Coefficients(1, c) });
        }

        public static LayoutSupportExpression operator -(LayoutSupport lhs, nfloat c)
        {
            return lhs + (-c);
        } 
    }
}
