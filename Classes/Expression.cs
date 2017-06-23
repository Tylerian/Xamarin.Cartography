using System;
using System.Linq;

using UIKit;

namespace Cartography
{
    public interface IExpression<T>
    {
        T Value { get; }
        Coefficients[] Coefficients { get; }
    }

    public class BaseExpression<T> : IExpression<T>
    {
        public T Value { get; }
        public Coefficients[] Coefficients { get; }

        public BaseExpression(T value, Coefficients[] coefficients)
        {
            Value = value;
            Coefficients = coefficients;
        }

        public static NSLayoutConstraint operator ==(IRelativeEquality lhs, BaseExpression<T> rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value as IProperty, coefficients: rhs.Coefficients?[0]);
        }

        public static NSLayoutConstraint operator !=(IRelativeEquality lhs, BaseExpression<T> rhs)
        {
            throw new NotImplementedException();
        }
    }

    public class SizeExpression : BaseExpression<Size>
    {
        public SizeExpression(Size value, Coefficients[] coefficients) : base(value, coefficients) { }

        public static SizeExpression operator *(nfloat m, SizeExpression rhs)
        {
            return new SizeExpression(rhs.Value, rhs.Coefficients.Select(x => x * m).ToArray());
        }

        public static SizeExpression operator *(SizeExpression lhs, nfloat rhs)
        {
            return rhs * lhs;
        }

        public static SizeExpression operator /(SizeExpression lhs, nfloat rhs)
        {
            return lhs * (1 / rhs);
        }
    }

    public class EdgesExpression : BaseExpression<Edges>
    {
        public EdgesExpression(Edges value, Coefficients[] coefficients) : base(value, coefficients) { }
    }

    public class AdditionExpression : BaseExpression<IAddition>
    {
        public AdditionExpression(IAddition value, Coefficients[] coefficients) : base(value, coefficients) { }

        public static AdditionExpression operator +(nfloat c, AdditionExpression rhs)
        {
            return new AdditionExpression(rhs.Value, rhs.Coefficients.Select(x => x + c).ToArray());
        }

        public static AdditionExpression operator +(AdditionExpression lhs, nfloat rhs)
        {
            return lhs + rhs;
        }

        public static AdditionExpression operator -(nfloat c, AdditionExpression rhs)
        {
            return new AdditionExpression(rhs.Value, rhs.Coefficients.Select(x => x + c).ToArray());
        }

        public static AdditionExpression operator -(AdditionExpression lhs, nfloat rhs)
        {
            return lhs - rhs;
        }
    }

    public class LayoutSupportExpression : BaseExpression<LayoutSupport>
    {
        public LayoutSupportExpression(LayoutSupport value, Coefficients[] coefficients) : base(value, coefficients) { }
    }

    public class MultiplicationExpression : BaseExpression<IMultiplication>
    {
        public MultiplicationExpression(IMultiplication value, Coefficients[] coefficients) : base(value, coefficients) { }

        public static MultiplicationExpression operator *(nfloat m, MultiplicationExpression rhs)
        {
            return new MultiplicationExpression(rhs.Value, rhs.Coefficients.Select(x => x * m).ToArray());
        }

        public static MultiplicationExpression operator *(MultiplicationExpression lhs, nfloat rhs)
        {
            return rhs * lhs;
        }

        public static MultiplicationExpression operator /(MultiplicationExpression lhs, nfloat rhs)
        {
            return lhs * (1 / rhs);
        }
    }

    public class RelativeEqualityExpression : BaseExpression<IRelativeEquality>
    {
        public RelativeEqualityExpression(IRelativeEquality value, Coefficients[] coefficients) : base(value, coefficients) { }

        public static NSLayoutConstraint operator ==(IRelativeEquality lhs, RelativeEqualityExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients?[0]);
        }

        public static NSLayoutConstraint operator !=(IRelativeEquality lhs, RelativeEqualityExpression rhs)
        {
            throw new NotImplementedException();
        }
    }

    /*
    public class NumericalEqualityExpression : BaseExpression<INumericalEquality>
    {
        public NumericalEqualityExpression(INumericalEquality value, Coefficients[] coefficients) : base(value, coefficients) { }

        public static NSLayoutConstraint operator ==(INumericalEquality lhs, NumericalEqualityExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients?[0]);
        }

        public static NSLayoutConstraint operator !=(INumericalEquality lhs, NumericalEqualityExpression rhs)
        {
            throw new NotImplementedException();
        }
    }
    */

    public class RelativeInequalityExpression : BaseExpression<IRelativeInequality>
    {
        public RelativeInequalityExpression(IRelativeInequality value, Coefficients[] coefficients) : base(value, coefficients) { }

        public static NSLayoutConstraint operator <=(IRelativeInequality lhs, RelativeInequalityExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients?[0], relation: NSLayoutRelation.LessThanOrEqual);
        }

        public static NSLayoutConstraint operator >=(IRelativeInequality lhs, RelativeInequalityExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients?[0], relation: NSLayoutRelation.GreaterThanOrEqual);
        }
    }

    /*
    public class NumericalInequalityExpression : BaseExpression<INumericalInequality>
    {
        public NumericalInequalityExpression(INumericalInequality value, Coefficients[] coefficients) : base(value, coefficients) { }

        public static NSLayoutConstraint operator <=(IRelativeInequality lhs, NumericalInequalityExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients?[0], layoutRelation: NSLayoutRelation.LessThanOrEqual);
        }

        public static NSLayoutConstraint operator >=(INumericalInequality lhs, NumericalInequalityExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients?[0], layoutRelation: NSLayoutRelation.GreaterThanOrEqual);
        }
    }
    */

    public class RelativeCompoundEqualityExpression : BaseExpression<IRelativeCompoundEquality>
    {
        public RelativeCompoundEqualityExpression(IRelativeCompoundEquality value, Coefficients[] coefficients) : base(value, coefficients) { }
    }

    public class RelativeCompoundInequalityExpression : BaseExpression<IRelativeCompoundInequality>
    {
        public RelativeCompoundInequalityExpression(IRelativeCompoundInequality value, Coefficients[] coefficients) : base(value, coefficients) { }
    }
}
