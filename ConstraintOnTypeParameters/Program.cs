using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintOnTypeParameters
{
    /// Struct : T는 값 형식이어야 한다
    class StructArray<T> where T : struct
    {
        public T[] Array { get; set; }
        public StructArray(int size)
        {
            Array = new T[size];
        }
    }

    /// Class : T는 참조 형식이어야 한다
    class RefArray<T> where T : class
    {
        public T[] Array { get; set; }
        public RefArray(int size)
        {
            Array = new T[size];
        }    
    }

    /// 기반클래스 : T는 명시한 기반 클래스의 파생 클래스여야 한다
    /// U : T는 또 다른 형식 매개변수 U로부터 상속받은 클래스여야 한다
    class Base { }
    class Derived : Base { }
    class BaseArray<U> where U : Base
    {
        public U[] Array { get; set; }
        public BaseArray(int size)
        {
            Array = new U[size];
        }

        public void CopyArray<T>(T[] Source) where T : U
        {
            Source.CopyTo(Array, 0);
        }
    }


    class Program
    {
        /// Create Instance
        public static T CreateInstance<T>() where T : new()
        {
            return new T();
        }

        static void Main(string[] args)
        {
            StructArray<int> a = new StructArray<int>(3);
            a.Array[0] = 0;
            a.Array[1] = 1;
            a.Array[2] = 2;

            for (int i = 0; i < a.Array.Length; i++)
            {
                Console.WriteLine("StructArray<int> : " + $"{a.Array[i]}");
            }

            RefArray<StructArray<double>> b = new RefArray<StructArray<double>>(3);
            b.Array[0] = new StructArray<double>(5);
            b.Array[1] = new StructArray<double>(10);
            b.Array[2] = new StructArray<double>(1005);

            for (int i = 0; i < b.Array.Length; i++)
            {
                Console.WriteLine("RefArray<StructArray<double>> : " + $"{b.Array[i].Array.Length}");
            }

            BaseArray<Base> c = new BaseArray<Base>(3);
            c.Array[0] = new Base();
            c.Array[1] = new Derived();
            c.Array[2] = CreateInstance<Base>();

            for (int i = 0; i < c.Array.Length; i++)
            {
                Console.WriteLine("BaseArray<Base> : " + $"{c.Array[i]}");
                Console.WriteLine("BaseArray<Base> Comparisom : " + $"{c.Array[0].Equals(c.Array[2])}");
            }

            BaseArray<Derived> d = new BaseArray<Derived>(3);
            d.Array[0] = new Derived(); // Base 형식은 여기에 할당할 수 없다
            d.Array[1] = CreateInstance<Derived>();
            d.Array[2] = CreateInstance<Derived>();

            for (int i = 0; i < d.Array.Length; i++)
            {
                Console.WriteLine("BaseArray<Derived> : " + $"{d.Array[i]}");
            }

            BaseArray<Derived> e = new BaseArray<Derived>(3);
            e.CopyArray<Derived>(d.Array);

            for (int i = 0; i < e.Array.Length; i++)
            {
                Console.WriteLine("BaseArray<Derived> (Copied) : " + $"{e.Array[i]}");
            }
        }
    }
}
