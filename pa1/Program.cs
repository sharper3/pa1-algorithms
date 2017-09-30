


using System;

namespace pa1
{
	class Program
	{
		static Random random = new Random();
		static SquareSet set = new SquareSet();
		static void Main(string[] args)
		{
			for (int i = 0; i < 10; i++)
			{
				int ran = random.Next(0, 100);
				Console.WriteLine("Add: " + ran);
				set.Add(ran);

			}
			Console.ReadLine();
		}
	}

	public class SquareSet
	{
		int?[] arraySmall;
		int?[] arrayLarge;

		int arraySmallLength = 2;
		int arrayLargeLength = 4;

		int arraySmallCount = 0;

		public SquareSet()
		{
			arraySmall = new int?[arraySmallLength];
			arrayLarge = new int?[arrayLargeLength];
			for (int i = 0; i < arraySmall.Length - 1; i++)
			{
				arraySmall[i] = null;
			}

		}
		public void Add(int value)
		{
			if (arraySmallCount != arraySmallLength)
			{
				arraySmall[arraySmallCount] = value;
				arraySmallCount++;
				InsertionSort(arraySmall);
			}
            if (arraySmallCount == arraySmallLength) //small array is full.  reallocate
            {
                Console.WriteLine("Small array full.  Reallocating...");
                ReallocateArrays();
            }
        }

        private void ReallocateArrays()
        {
            int?[] tempArray = CombineArrays(arrayLarge, arraySmall);
            arrayLargeLength = tempArray.Length;
            arrayLarge = tempArray;
            arraySmallLength = Convert.ToInt32(Math.Sqrt(arrayLargeLength));
            arraySmall = new int?[arraySmallLength];
            arraySmallCount = 0;

            Console.WriteLine("Long Array:");
            for (int i = 0; i < arrayLarge.Length; i++)
            {
                Console.WriteLine(i + ":" + arrayLarge[i]);
            }
        }

        private int?[] CombineArrays(int?[] one, int?[] two)
        {
            int?[] tempArray = new int?[one.Length + two.Length];
            for (int i = 0; i < one.Length; i++)
            {
                tempArray[i] = one[i];
            }
			Console.WriteLine("temparray before add small: ");
			for (int i = 0; i < tempArray.Length; i++)
			  {
			      Console.WriteLine(i + " : " + tempArray[i]);
			  }
			for (int i = 0; i < two.Length; i++)
            {
                int j = i + one.Length;
                tempArray[j] = two[i];
            }
			Console.WriteLine("temparray after add small: ");
			for (int i = 0; i < tempArray.Length; i++)
			{
				Console.WriteLine(i + " : " + tempArray[i]);
			}

            return tempArray;
        }

        private void InsertionSort(int?[] array)
		{

			//Console.WriteLine("Array before sort: ");
			//for (int i = 0; i < array.Length; i++)
		//	{
		//		Console.WriteLine(i + " : " + array[i]);
		//	}
			
			for (int i = 1; i < array.Length - 1; i++)
			{
				int? x = array[i];
				if (x == null)
				{
					break;
				}
				int j = i + 1;

				while (j > 0)
				{
					if (arraySmall[j - 1] > arraySmall[j])
					{
						int? temp = arraySmall[j - 1];
						arraySmall[j - 1] = arraySmall[j];
						arraySmall[j] = temp;

					}
					j--;
				}
			}
			//Console.WriteLine("Array after sort: ");
			//for (int i = 0; i < array.Length; i++)
			//{
			//	Console.WriteLine(i + " : " + array[i]);
			//}
		}
	}
}