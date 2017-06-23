using System;

using UIKit;

namespace Cartography
{
    public class Point : ICompound, IRelativeCompoundEquality, IRelativeCompoundInequality
    {
        public Context Context { get; }
        public IProperty[] Properties { get; }

        internal Point(Context context, IProperty[] properties)
        {
            Context = context;
            Properties = properties;
        }

        #region IRelativeCompoundEquality Operators
        public static NSLayoutConstraint[] operator ==(Point lhs, IRelativeCompoundEquality rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs);
        }

        public static NSLayoutConstraint[] operator !=(Point lhs, IRelativeCompoundEquality rhs)
        {
            throw new NotImplementedException();
        }

        /*
        public static NSLayoutConstraint[] operator ==(IRelativeCompoundEquality lhs, Point rhs)
        {
            return rhs == lhs;
        }

        public static NSLayoutConstraint[] operator !=(IRelativeCompoundEquality lhs, Point rhs)
        {
            return rhs != lhs;
        }
        */

        public static NSLayoutConstraint[] operator ==(Point lhs, RelativeCompoundEqualityExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients);
        }

        public static NSLayoutConstraint[] operator !=(Point lhs, RelativeCompoundEqualityExpression rhs)
        {
            throw new NotImplementedException();
        }

        /*
        public static NSLayoutConstraint[] operator ==(RelativeCompoundEqualityExpression lhs, Point rhs)
        {
            return rhs == lhs;
        }

        public static NSLayoutConstraint[] operator !=(RelativeCompoundEqualityExpression lhs, Point rhs)
        {
            return rhs != lhs;
        }
        */
        #endregion

        #region IRelativeCompoundInequality Operators
        public static NSLayoutConstraint[] operator <=(Point lhs, IRelativeCompoundInequality rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs, relation: NSLayoutRelation.LessThanOrEqual);
        }

        public static NSLayoutConstraint[] operator >=(Point lhs, IRelativeCompoundInequality rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs, relation: NSLayoutRelation.GreaterThanOrEqual);
        }

        /*
        public static NSLayoutConstraint[] operator <=(IRelativeCompoundInequality lhs, Point rhs)
        {
            return rhs <= lhs;
        }

        public static NSLayoutConstraint[] operator >=(IRelativeCompoundInequality lhs, Point rhs)
        {
            return rhs >= lhs;
        }
        */

        public static NSLayoutConstraint[] operator <=(Point lhs, RelativeCompoundInequalityExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients, relation: NSLayoutRelation.LessThanOrEqual);
        }

        public static NSLayoutConstraint[] operator >=(Point lhs, RelativeCompoundInequalityExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients, relation: NSLayoutRelation.GreaterThanOrEqual);
        }

        /*
        public static NSLayoutConstraint[] operator <=(RelativeCompoundInequalityExpression lhs, Point rhs)
        {
            return rhs <= lhs;
        }

        public static NSLayoutConstraint[] operator >=(RelativeCompoundInequalityExpression lhs, Point rhs)
        {
            return rhs >= lhs;
        }
        */
        #endregion
    }
}
