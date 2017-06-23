using System;

using UIKit;

namespace Cartography
{
    public class Size : ICompound, IRelativeCompoundEquality, IRelativeCompoundInequality
    {
        public Context Context { get; }
        public IProperty[] Properties { get; }

        internal Size(Context context, IProperty[] properties)
        {
            Context = context;
            Properties = properties;
        }

        #region IMultiplication Operators
        public static SizeExpression operator *(nfloat m, Size rhs)
        {
            return new SizeExpression(rhs, new[] { new Coefficients(m, 0), new Coefficients(m, 0) });
        }

        public static SizeExpression operator *(Size lhs, nfloat rhs)
        {
            return rhs * lhs;
        }

        public static SizeExpression operator /(Size lhs, nfloat rhs)
        {
            return lhs * (1 / rhs);
        }
        #endregion

        #region IRelativeCompoundEquality Operators
        public static NSLayoutConstraint[] operator ==(Size lhs, IRelativeCompoundEquality rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs);
        }

        public static NSLayoutConstraint[] operator !=(Size lhs, IRelativeCompoundEquality rhs)
        {
            throw new NotImplementedException();
        }

        /*
        public static NSLayoutConstraint[] operator ==(IRelativeCompoundEquality lhs, Size rhs)
        {
            return rhs == lhs;
        }

        public static NSLayoutConstraint[] operator !=(IRelativeCompoundEquality lhs, Size rhs)
        {
            return rhs != lhs;
        }
        */

        public static NSLayoutConstraint[] operator ==(Size lhs, RelativeCompoundEqualityExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients);
        }

        public static NSLayoutConstraint[] operator !=(Size lhs, RelativeCompoundEqualityExpression rhs)
        {
            throw new NotImplementedException();
        }

        /*
        public static NSLayoutConstraint[] operator ==(RelativeCompoundEqualityExpression lhs, Size rhs)
        {
            return rhs == lhs;
        }

        public static NSLayoutConstraint[] operator !=(RelativeCompoundEqualityExpression lhs, Size rhs)
        {
            return rhs != lhs;
        }
        */
        #endregion

        #region IRelativeCompoundInequality Operators
        public static NSLayoutConstraint[] operator <=(Size lhs, IRelativeCompoundInequality rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs, relation: NSLayoutRelation.LessThanOrEqual);
        }

        public static NSLayoutConstraint[] operator >=(Size lhs, IRelativeCompoundInequality rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs, relation: NSLayoutRelation.GreaterThanOrEqual);
        }

        /*
        public static NSLayoutConstraint[] operator <=(IRelativeCompoundInequality lhs, Size rhs)
        {
            return rhs <= lhs;
        }

        public static NSLayoutConstraint[] operator >=(IRelativeCompoundInequality lhs, Size rhs)
        {
            return rhs >= lhs;
        }
        */

        public static NSLayoutConstraint[] operator <=(Size lhs, RelativeCompoundInequalityExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients, relation: NSLayoutRelation.LessThanOrEqual);
        }

        public static NSLayoutConstraint[] operator >=(Size lhs, RelativeCompoundInequalityExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients, relation: NSLayoutRelation.GreaterThanOrEqual);
        }

        /*
        public static NSLayoutConstraint[] operator <=(RelativeCompoundInequalityExpression lhs, Size rhs)
        {
            return rhs <= lhs;
        }

        public static NSLayoutConstraint[] operator >=(RelativeCompoundInequalityExpression lhs, Size rhs)
        {
            return rhs >= lhs;
        }
        */
        #endregion
    }
}
