

namespace CGAME
{
    [System.Serializable]
    public struct Vector2
    {
        public double x;
        public double y;

        public Vector2(double _x, double _y)
        {
            this.x = _x;
            this.y = _y;
        }

        public Vector2(Vector2 _vector)
        {
            this.x = _vector.x;
            this.y = _vector.y;
        }

        public Vector2 add(Vector2 _vec1, Vector2 _vec2)
        {
            return new Vector2(_vec1.x + _vec2.x, _vec1.y + _vec2.y);
        }

        public Vector2 sub(Vector2 _vec1, Vector2 _vec2)
        {
            return new Vector2(_vec1.x - _vec2.x, _vec1.y - _vec2.y);
        }

        public Vector2 mult(Vector2 _vec1, Vector2 _vec2)
        {
            return new Vector2(_vec1.x * _vec2.x, _vec1.y * _vec2.y);
        }

        public static Vector2 operator +(Vector2 _v, double _f)
        {
            return new Vector2(_v.x += _f, _v.y += _f);
        }

        public static Vector2 operator -(Vector2 _v, double _f)
        {
            return new Vector2(_v.x -= _f, _v.y -= _f);
        }

        public static Vector2 operator *(Vector2 _v, double _f)
        {
            return new Vector2(_v.x *= _f, _v.y *= _f);
        }
        public static Vector2 operator +(Vector2 _v1, Vector2 _v2)
        {
            return new Vector2(_v1.x + _v2.x, _v1.y + _v2.y);
        }

        public static Vector2 operator -(Vector2 _v1, Vector2 _v2)
        {
            return new Vector2(_v1.x - _v2.x, _v1.y - _v2.y);
        }

        public static Vector2 operator *(Vector2 _v1, Vector2 _v2)
        {
            return new Vector2(_v1.x * _v2.x, _v1.y * _v2.y);
        }
        public static double distance(Vector2 _v1, Vector2 _v2)
        {
            return System.Math.Sqrt(((_v2.x - _v1.x) * (_v2.x - _v1.x)) + ((_v2.y - _v1.y) * (_v2.y - _v1.y)));
        }

        public double Length()
        {
            return System.Math.Sqrt((x * x) + (x * x) + (x * x));
        }

        public Vector2 Normalize()
        {
            return new Vector2(x * (1.0 / Length()), y * (1.0 / Length()));
        }
    }
}
