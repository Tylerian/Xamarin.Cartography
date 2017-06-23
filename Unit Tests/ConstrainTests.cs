using System;

using UIKit;

using Cartography;

namespace Cartography.Unit_Tests
{
    class ConstrainTests
    {
        public static void Main(string[] args)
        {
            var theView = new UIView();
            var theBttn = new UIButton();

            Cartography.Constrain(theView, theBttn, (view1, view2) =>
            {
                var z = (view1.Width == view2.Width + 15);
                    z = (view1.Height == view2.Height * 3);
            });
        }
    }
}
