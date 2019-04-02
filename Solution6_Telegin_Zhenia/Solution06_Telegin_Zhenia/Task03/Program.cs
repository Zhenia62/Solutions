using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            IIndexable();
            Console.ReadKey();
        }
        public static void IIndexable()
        {
            ArithmeticalProgression progression = new ArithmeticalProgression(2,2);
            Console.WriteLine("number = " + progression[2]);
            Console.WriteLine("number = " + progression[6]);

        }
    }
    public class ArithmeticalProgression : ISeries, IIndexable
    {
        double start, step;
        int currentIndex;

        public ArithmeticalProgression(double start, double step)
        {
            this.start = start;
            this.step = step;
            this.currentIndex = 1;
        }

        public double GetCurrent()
        {
            return start + step * currentIndex;
        }

        public bool MoveNext()
        {
            currentIndex++;
            return true;
        }

        public double this[int index]
		{
			get
			{
				return start + step * index;
			}
		}
    }

    public class List : ISeries, IIndexable
    {
        private double[] series;
        private int currentIndex;

        public List(double[] series)
        {
            this.series = series;
            currentIndex = 0;
        }

        public double GetCurrent()
        {
            return series[currentIndex];
        }

        public bool MoveNext()
        {
            currentIndex = currentIndex < series.Length - 1 ? currentIndex + 1 : 0;
            return true;
        }


        public double this[int index]
		{
			get { return series[index]; }
		}
    }
    public interface ISeries
    {
        double GetCurrent();
        bool MoveNext();
    }

    public interface IIndexable
    {
        double this[int index] { get; }
    }
}

