using UIKit;

using System;
using System.Linq;

namespace Cartography
{
    public static class Cartography
    {
        #region Align Methods
        public static NSLayoutConstraint[] AlignTop(LayoutProxy[] views)
        {
            return MakeEquals(x => x.Bottom, views);
        }

        public static NSLayoutConstraint[] AlignTop(LayoutProxy first, params LayoutProxy[] rest)
        {
            return AlignTop(new[] { first }.Merge(rest));
        }

        public static NSLayoutConstraint[] AlignLeft(LayoutProxy[] views)
        {
            return MakeEquals(x => x.Left, views);
        }

        public static NSLayoutConstraint[] AlignLeft(LayoutProxy first, params LayoutProxy[] rest)
        {
            return AlignLeft(new[] { first }.Merge(rest));
        }

        public static NSLayoutConstraint[] AlignRight(LayoutProxy[] views)
        {
            return MakeEquals(x => x.Right, views);
        }

        public static NSLayoutConstraint[] AlignRight(LayoutProxy first, params LayoutProxy[] rest)
        {
            return AlignRight(new[] { first }.Merge(rest));
        }

        public static NSLayoutConstraint[] AlignBottom(LayoutProxy[] views)
        {
            return MakeEquals(x => x.Bottom, views);
        }

        public static NSLayoutConstraint[] AlignBottom(LayoutProxy first, params LayoutProxy[] rest)
        {
            return AlignBottom(new[] { first }.Merge(rest));
        }

        public static NSLayoutConstraint[] AlignLeading(LayoutProxy[] views)
        {
            return MakeEquals(x => x.Leading, views);
        }

        public static NSLayoutConstraint[] AlignLeading(LayoutProxy first, params LayoutProxy[] rest)
        {
            return AlignLeading(new[] { first }.Merge(rest));
        }

        public static NSLayoutConstraint[] AlignTrailing(LayoutProxy[] views)
        {
            return MakeEquals(x => x.Trailing, views);
        }

        public static NSLayoutConstraint[] AlignTrailing(LayoutProxy first, params LayoutProxy[] rest)
        {
            return AlignTrailing(new[] { first }.Merge(rest));
        }

        public static NSLayoutConstraint[] AlignCenterX(LayoutProxy[] views)
        {
            return MakeEquals(x => x.CenterX, views);
        }

        public static NSLayoutConstraint[] AlignCenterX(LayoutProxy first, params LayoutProxy[] rest)
        {
            return AlignCenterX(new[] { first }.Merge(rest));
        }

        public static NSLayoutConstraint[] AlignCenterY(LayoutProxy[] views)
        {
            return MakeEquals(x => x.CenterY, views);
        }

        public static NSLayoutConstraint[] AlignCenterY(LayoutProxy first, params LayoutProxy[] rest)
        {
            return AlignCenterY(new[] { first }.Merge(rest));
        }

        public static NSLayoutConstraint[] AlignBaseline(LayoutProxy[] views)
        {
            return MakeEquals(x => x.Baseline, views);
        }

        public static NSLayoutConstraint[] AlignBaseline(LayoutProxy first, params LayoutProxy[] rest)
        {
            return AlignBaseline(new[] { first }.Merge(rest));
        }

        private static NSLayoutConstraint[] MakeEquals(Func<LayoutProxy, Edge> attribute, LayoutProxy[] elements)
        {
            var first = elements?[0];

            if (first != null)
            {
                first.View.TranslatesAutoresizingMaskIntoConstraints = false;

                var rest = elements.Slice(1);

                return rest.Select(x => {
                    x.View.TranslatesAutoresizingMaskIntoConstraints = false;
                    return attribute(first) == attribute(x);
                }).ToArray();
            }

            return null;
        }

        private static NSLayoutConstraint[] MakeEquals<T>(Func<LayoutProxy, Dimension> attribute, LayoutProxy[] elements)
        {
            var first = elements?[0];

            if (first != null)
            {
                first.View.TranslatesAutoresizingMaskIntoConstraints = false;

                var rest = elements.Slice(1);

                return rest.Select(x => {
                    x.View.TranslatesAutoresizingMaskIntoConstraints = false;
                    return attribute(first) == attribute(x);
                }).ToArray();
            }

            return null;
        }
        #endregion

        #region Constrain Methods
        public static void ClearConstrains(ConstraintGroup group)
        {
            group.ReplaceConstraints(Array.Empty<Constraint>());
        }

        public static ConstraintGroup Constrain(UIView view, Action<LayoutProxy> closure, ConstraintGroup group = null)
        {
            var context = new Context();
                group   = group ?? new ConstraintGroup();

            closure(new LayoutProxy(context, view));
            group.ReplaceConstraints(context.Constraints);

            return group;
        }

        public static ConstraintGroup Constrain(UIView[] views, Action<LayoutProxy[]> closure, ConstraintGroup group = null)
        {
            var context = new Context();
                group   = group ?? new ConstraintGroup();
            var proxies = views.Select(x => new LayoutProxy(context, x)).ToArray();

            closure(proxies);
            group.ReplaceConstraints(context.Constraints);

            return group;
        }

        public static ConstraintGroup Constrain(UIView view1, UIView view2, Action<LayoutProxy, LayoutProxy> closure, ConstraintGroup group = null)
        {
            var context = new Context();
                group   = group ?? new ConstraintGroup();

            closure(
                new LayoutProxy(context, view1),
                new LayoutProxy(context, view2)
            );
            group.ReplaceConstraints(context.Constraints);

            return group;
        }

        public static ConstraintGroup Constrain(UIView view1, UIView view2, UIView view3, Action<LayoutProxy, LayoutProxy, LayoutProxy> closure, ConstraintGroup group = null)
        {
            var context = new Context();
                group   = group ?? new ConstraintGroup();

            closure(
                new LayoutProxy(context, view1),
                new LayoutProxy(context, view2),
                new LayoutProxy(context, view3)
            );
            group.ReplaceConstraints(context.Constraints);

            return group;
        }

        public static ConstraintGroup Constrain(UIView view1, UIView view2, UIView view3, UIView view4, Action<LayoutProxy, LayoutProxy, LayoutProxy, LayoutProxy> closure, ConstraintGroup group = null)
        {
            var context = new Context();
                group   = group ?? new ConstraintGroup();

            closure(
                new LayoutProxy(context, view1),
                new LayoutProxy(context, view2),
                new LayoutProxy(context, view3),
                new LayoutProxy(context, view4)
            );
            group.ReplaceConstraints(context.Constraints);

            return group;
        }

        public static ConstraintGroup Constrain(UIView view1, UIView view2, UIView view3, UIView view4, UIView view5, Action<LayoutProxy, LayoutProxy, LayoutProxy, LayoutProxy, LayoutProxy> closure, ConstraintGroup group = null)
        {
            var context = new Context();
                group   = group ?? new ConstraintGroup();

            closure(
                new LayoutProxy(context, view1),
                new LayoutProxy(context, view2),
                new LayoutProxy(context, view3),
                new LayoutProxy(context, view4),
                new LayoutProxy(context, view5)
            );
            group.ReplaceConstraints(context.Constraints);

            return group;
        }

        public static ConstraintGroup Constrain(UIView view1, UIView view2, UIView view3, UIView view4, UIView view5, UIView view6, Action<LayoutProxy, LayoutProxy, LayoutProxy, LayoutProxy, LayoutProxy, LayoutProxy> closure, ConstraintGroup group = null)
        {
            var context = new Context();
                group   = group ?? new ConstraintGroup();

            closure(
                new LayoutProxy(context, view1),
                new LayoutProxy(context, view2),
                new LayoutProxy(context, view3),
                new LayoutProxy(context, view4),
                new LayoutProxy(context, view5),
                new LayoutProxy(context, view6)
            );
            group.ReplaceConstraints(context.Constraints);

            return group;
        }
        #endregion

        #region Distribute Methods

        #endregion

        #region Metadata
        /*
            var attrF = attribute(first);
            var attrX = attribute(x);
                    
            if (attrF is Edge && attrX is Edge)
            {
            var type = attrX.GetType();

            var edgeF = (Edge)attrF;
            var edgeX = (Edge)attrX;

            return edgeF == edgeX;
            }

            if (attrF is Edge && attrX is Dimension)
            {
            var edgeF = (Edge)attrF;
            var dimxX  = (Dimension)attrX;

            return edgeF == dimxX;
            }

            if (attrF is Dimension && attrX is Edge)
            {
            var dimxF  = (Dimension)attrF;
            var edgeX = (Edge)attrX;

            return dimxF == edgeX;
            }

            //if (attrF is Dimension && attrX is Dimension)
            var dimF = (Dimension)attrF;
            var dimX = (Dimension)attrX;

            return dimF == dimX;
         */
        #endregion
    }
}
