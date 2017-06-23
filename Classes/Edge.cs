using System;

using UIKit;

namespace Cartography
{
    public class Edge : IProperty, IRelativeEquality, IRelativeInequality, IAddition, IMultiplication
    {
        public UIView View { get; }
        public Context Context { get; }
        public NSLayoutAttribute Attribute { get; }

        internal Edge(Context context, UIView view, NSLayoutAttribute attribute)
        {
            View = view;
            Context = context;
            Attribute = attribute;
        }

        #region IAddition Operators
        public static AdditionExpression operator +(nfloat c, Edge rhs)
        {
            return new AdditionExpression(rhs, new[] { new Coefficients(1, c) });
        }

        public static AdditionExpression operator +(Edge lhs, nfloat rhs)
        {
            return rhs + lhs;
        }

        public static AdditionExpression operator -(nfloat c, Edge rhs)
        {
            return new AdditionExpression(rhs, new[] { new Coefficients(1, -c) });
        }

        public static AdditionExpression operator -(Edge lhs, nfloat rhs)
        {
            return rhs - lhs;
        }
        #endregion

        #region IMultiplication Operators
        public static MultiplicationExpression operator *(nfloat m, Edge rhs)
        {
            return new MultiplicationExpression(rhs, new[] { new Coefficients(m, 0) });
        }

        public static MultiplicationExpression operator *(Edge lhs, nfloat rhs)
        {
            return rhs * lhs;
        }

        public static MultiplicationExpression operator /(Edge lhs, nfloat rhs)
        {
            return lhs * (1 / rhs);
        }
        #endregion

        #region IRelativeEquality Operators
        public static NSLayoutConstraint operator ==(Edge lhs, LayoutSupport rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs);
        }

        public static NSLayoutConstraint operator !=(Edge lhs, LayoutSupport rhs)
        {
            throw new NotImplementedException();
        }

        public static NSLayoutConstraint operator ==(Edge lhs, IRelativeEquality rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs);
        }

        public static NSLayoutConstraint operator !=(Edge lhs, IRelativeEquality rhs)
        {
            throw new NotImplementedException();
        }

        public static NSLayoutConstraint operator ==(Edge lhs, LayoutSupportExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients?[0]);
        }

        public static NSLayoutConstraint operator !=(Edge lhs, LayoutSupportExpression rhs)
        {
            throw new NotImplementedException();
        }

        public static NSLayoutConstraint operator <=(Edge lhs, LayoutSupport rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs, relation: NSLayoutRelation.LessThanOrEqual);
        }

        public static NSLayoutConstraint operator >=(Edge lhs, LayoutSupport rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs, relation: NSLayoutRelation.GreaterThanOrEqual);
        }

        public static NSLayoutConstraint operator <=(Edge lhs, LayoutSupportExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients?[0], relation: NSLayoutRelation.LessThanOrEqual);
        }

        public static NSLayoutConstraint operator >=(Edge lhs, LayoutSupportExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients?[0], relation: NSLayoutRelation.GreaterThanOrEqual);
        }
        #endregion

        #region IRelativeInequality Operators
        public static NSLayoutConstraint operator <=(Edge lhs, IRelativeInequality rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs, relation: NSLayoutRelation.LessThanOrEqual);
        }

        public static NSLayoutConstraint operator >=(Edge lhs, IRelativeInequality rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs, relation: NSLayoutRelation.GreaterThanOrEqual);
        }
        #endregion
    }
}
