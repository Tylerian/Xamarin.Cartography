using UIKit;

using System;

namespace Cartography
{
    public class Dimension : IProperty, INumericalEquality, IRelativeEquality, INumericalInequality, IRelativeInequality, IAddition, IMultiplication
    {
        public UIView View { get; }
        public Context Context { get; }
        public NSLayoutAttribute Attribute { get; }

        public Dimension(Context context, UIView view, NSLayoutAttribute attribute)
        {
            View = view;
            Context = context;
            Attribute = attribute;
        }

        #region IAddition Operators
        public static AdditionExpression operator +(nfloat c, Dimension rhs)
        {
            return new AdditionExpression(rhs, new[] { new Coefficients(1, c) });
        }

        public static AdditionExpression operator +(Dimension lhs, nfloat rhs)
        {
            return rhs + lhs;
        }

        public static AdditionExpression operator -(nfloat c, Dimension rhs)
        {
            return new AdditionExpression(rhs, new[] { new Coefficients(1, -c) });
        }

        public static AdditionExpression operator -(Dimension lhs, nfloat rhs)
        {
            return rhs - lhs;
        }
        #endregion

        #region IMultiplication Operators
        public static MultiplicationExpression operator *(nfloat m, Dimension rhs)
        {
            return new MultiplicationExpression(rhs, new[] { new Coefficients(m, 0) });
        }

        public static MultiplicationExpression operator *(Dimension lhs, nfloat rhs)
        {
            return rhs * lhs;
        }

        public static MultiplicationExpression operator /(Dimension lhs, nfloat rhs)
        {
            return lhs * (1 / rhs);
        }
        #endregion

        #region IRelativeEquality Operators
        public static NSLayoutConstraint operator ==(Dimension lhs, LayoutSupport rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs);
        }

        public static NSLayoutConstraint operator !=(Dimension lhs, LayoutSupport rhs)
        {
            throw new NotImplementedException();
        }

        public static NSLayoutConstraint operator ==(Dimension lhs, IRelativeEquality rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs);
        }

        public static NSLayoutConstraint operator !=(Dimension lhs, IRelativeEquality rhs)
        {
            throw new NotImplementedException();
        }

        public static NSLayoutConstraint operator ==(Dimension lhs, LayoutSupportExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients?[0]);
        }

        public static NSLayoutConstraint operator !=(Dimension lhs, LayoutSupportExpression rhs)
        {
            throw new NotImplementedException();
        }

        public static NSLayoutConstraint operator <=(Dimension lhs, LayoutSupport rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs, relation: NSLayoutRelation.LessThanOrEqual);
        }

        public static NSLayoutConstraint operator >=(Dimension lhs, LayoutSupport rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs, relation: NSLayoutRelation.GreaterThanOrEqual);
        }

        public static NSLayoutConstraint operator <=(Dimension lhs, LayoutSupportExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients?[0], relation: NSLayoutRelation.LessThanOrEqual);
        }

        public static NSLayoutConstraint operator >=(Dimension lhs, LayoutSupportExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients?[0], relation: NSLayoutRelation.GreaterThanOrEqual);
        }
        #endregion

        #region INumericalEquality Operators
        public static NSLayoutConstraint operator ==(Dimension lhs, nfloat rhs)
        {
            return lhs.Context.AddConstraint(lhs, coefficients: new Coefficients(1, rhs));
        }

        public static NSLayoutConstraint operator !=(Dimension lhs, nfloat rhs)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IRelativeInequality Operators
        public static NSLayoutConstraint operator <=(Dimension lhs, IRelativeInequality rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs, relation: NSLayoutRelation.LessThanOrEqual);
        }

        public static NSLayoutConstraint operator >=(Dimension lhs, IRelativeInequality rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs, relation: NSLayoutRelation.GreaterThanOrEqual);
        }
        #endregion

        #region INumericalInequality Operators
        public static NSLayoutConstraint operator <=(Dimension lhs, nfloat rhs)
        {
            return lhs.Context.AddConstraint(lhs, coefficients: new Coefficients(1, rhs), relation: NSLayoutRelation.LessThanOrEqual);
        }

        public static NSLayoutConstraint operator >=(Dimension lhs, nfloat rhs)
        {
            return lhs.Context.AddConstraint(lhs, coefficients: new Coefficients(1, rhs), relation: NSLayoutRelation.GreaterThanOrEqual);
        }
        #endregion
    }
}
