using System;
using System.Collections.Generic;

public static class Square
{
    //Поддерживаемые фигуры
    public enum Shape
    {
        Triangle,
        Circle
    }

    public static double getSquere(double[] _params)
    {
        Shape shape;
        switch (_params.Length)
        {
            case 1:
                shape = Shape.Circle;
                break;
            case 3:
                shape = Shape.Triangle;
                break;
            default:
                throw new NotImplementedException();
        }

        return _getSquere(shape, _params);
    }

    public static double getSquere(double[] _params, Shape shape)
    {
        return _getSquere(shape, _params);
    }

    private static double _getSquere(Shape shape, double[] _params)
    {
        foreach (double _value in _params)
            if (_value <= 0 || !double.IsFinite(_value))
                throw new ArgumentException();
        switch (shape)
        {
            //Площадь круга
            case Shape.Circle:
                if (_params.Length != 1)
                    throw new ArgumentException();
                return Math.Pow(_params[0], 2) * Math.PI;
            //Площадь треугольника
            case Shape.Triangle:
                //наибольшая сторона - сортировка
                if (_params.Length != 3)
                    throw new ArgumentException();
                List<double> value = new List<double>(_params);
                value.Sort();
                if (Math.Pow(value[value.Count - 1], 2) == Math.Pow(value[value.Count - 2], 2) + Math.Pow(value[value.Count - 3], 2))
                {
                    return value[value.Count - 2] * value[value.Count - 3] / 2.0d;
                }
                else
                {
                    double p = (_params[0] + _params[1] + _params[2]) / 2.0d;
                    return Math.Sqrt(p * (p - _params[0]) * (p - _params[1]) * (p - _params[2]));
                }
            default:
                throw new NotImplementedException();
        }
    }
}
