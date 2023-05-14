using System;

namespace practice1
{
    class Program
    {
        static void Main(string[] args)
        {
            float [,] score = new float[2,5];
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    Console.Write("Score : ");
                    score[row, col] = float.Parse(Console.ReadLine());
                }
            }

            for (int row = 0; row < 2; row++)
            {
                float sum = 0;
                for (int col = 0; col < 5; col++)
                {
                    sum += score[row, col];
                }
                Console.WriteLine(sum);
            }

        }   
    }
}
