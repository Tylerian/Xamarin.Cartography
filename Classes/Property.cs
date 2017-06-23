using System;

using UIKit;

namespace Cartography
{
    public interface IProperty
    {
        UIView View { get; }
        Context Context { get; }
        NSLayoutAttribute Attribute { get; }
    }

    internal abstract class BaseProperty : IProperty
    {
        public UIView View { get; }
        public Context Context { get; }
        public NSLayoutAttribute Attribute { get; }

        public BaseProperty(Context context, UIView view, NSLayoutAttribute attribute)
        {
            View = view;
            Context = context;
            Attribute = attribute;
        }
    }

    public interface IAddition : IProperty { }

    internal abstract class Addition : BaseProperty, IAddition
    {
        public Addition(Context context, UIView view, NSLayoutAttribute attribute) : base(context, view, attribute) { }

        public static AdditionExpression operator +(nfloat c, Addition rhs)
        {
            return new AdditionExpression(rhs, new[] { new Coefficients(1, c) });
        }

        public static AdditionExpression operator +(Addition lhs, nfloat rhs)
        {
            return rhs + lhs;
        }

        public static AdditionExpression operator -(nfloat c, Addition rhs)
        {
            return new AdditionExpression(rhs, new[] { new Coefficients(1, -c) });
        }

        public static AdditionExpression operator -(Addition lhs, nfloat rhs)
        {
            return rhs - lhs;
        }
    }

    public interface IMultiplication : IProperty { }

    internal abstract class Multiplication : BaseProperty, IMultiplication
    {
        public Multiplication(Context context, UIView view, NSLayoutAttribute attribute) : base(context, view, attribute) { }

        public static MultiplicationExpression operator *(nfloat m, Multiplication rhs)
        {
            return new MultiplicationExpression(rhs, new[] { new Coefficients(m, 0) });
        }

        public static MultiplicationExpression operator *(Multiplication lhs, nfloat rhs)
        {
            return rhs * lhs;
        }

        public static MultiplicationExpression operator /(Multiplication lhs, nfloat rhs)
        {
            return lhs * (1 / rhs);
        }
    }

    public interface IRelativeEquality : IProperty
    {
    }

    internal abstract class RelativeEquality : BaseProperty, IRelativeEquality
    {
        public RelativeEquality(Context context, UIView view, NSLayoutAttribute attribute) : base(context, view, attribute) { }

        public static NSLayoutConstraint operator ==(RelativeEquality lhs, LayoutSupport rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs);
        }

        public static NSLayoutConstraint operator !=(RelativeEquality lhs, LayoutSupport rhs)
        {
            throw new NotImplementedException();
        }

        public static NSLayoutConstraint operator ==(RelativeEquality lhs, RelativeEquality rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs);
        }

        public static NSLayoutConstraint operator !=(RelativeEquality lhs, RelativeEquality rhs)
        {
            throw new NotImplementedException();
        }

        public static NSLayoutConstraint operator ==(RelativeEquality lhs, LayoutSupportExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients?[0]);
        }

        public static NSLayoutConstraint operator !=(RelativeEquality lhs, LayoutSupportExpression rhs)
        {
            throw new NotImplementedException();
        }

        public static NSLayoutConstraint operator <=(RelativeEquality lhs, LayoutSupport rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs, relation: NSLayoutRelation.LessThanOrEqual);
        }

        public static NSLayoutConstraint operator >=(RelativeEquality lhs, LayoutSupport rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs, relation: NSLayoutRelation.GreaterThanOrEqual);
        }

        public static NSLayoutConstraint operator <=(RelativeEquality lhs, LayoutSupportExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients?[0], relation: NSLayoutRelation.LessThanOrEqual);
        }

        public static NSLayoutConstraint operator >=(RelativeEquality lhs, LayoutSupportExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients?[0], relation: NSLayoutRelation.GreaterThanOrEqual);
        }
    }

    public interface INumericalEquality : IProperty { }

    internal abstract class NumericalEquality : BaseProperty, INumericalEquality
    {
        public NumericalEquality(Context context, UIView view, NSLayoutAttribute attribute) : base(context, view, attribute) { }

        public static NSLayoutConstraint operator ==(NumericalEquality lhs, nfloat rhs)
        {
            return lhs.Context.AddConstraint(lhs, coefficients: new Coefficients(1, rhs));
        }

        public static NSLayoutConstraint operator !=(NumericalEquality lhs, nfloat rhs)
        {
            throw new NotImplementedException();
        }
    }

    public interface IRelativeInequality : IProperty { }

    internal abstract class RelativeInequality : BaseProperty, IRelativeInequality
    {
        public RelativeInequality(Context context, UIView view, NSLayoutAttribute attribute) : base(context, view, attribute) { }

        public static NSLayoutConstraint operator <=(RelativeInequality lhs, RelativeInequality rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs, relation: NSLayoutRelation.LessThanOrEqual);
        }

        public static NSLayoutConstraint operator >=(RelativeInequality lhs, RelativeInequality rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs, relation: NSLayoutRelation.GreaterThanOrEqual);
        }
    }

    public interface INumericalInequality : IProperty { }

    internal abstract class NumericalInequality : BaseProperty, INumericalInequality
    {
        public NumericalInequality(Context context, UIView view, NSLayoutAttribute attribute) : base(context, view, attribute) { }

        public static NSLayoutConstraint operator <=(NumericalInequality lhs, nfloat rhs)
        {
            return lhs.Context.AddConstraint(lhs, coefficients: new Coefficients(1, rhs), relation: NSLayoutRelation.LessThanOrEqual);
        }

        public static NSLayoutConstraint operator >=(NumericalInequality lhs, nfloat rhs)
        {
            return lhs.Context.AddConstraint(lhs, coefficients: new Coefficients(1, rhs), relation: NSLayoutRelation.GreaterThanOrEqual);
        }
    }
}
