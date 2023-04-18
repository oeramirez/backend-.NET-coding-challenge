using System;

/*
 
    *
   ***
  *****
 *******
*********

ACCEPTANCE CRITERIA:
Write a script to output this pyramid on console (with leading spaces)

*/
namespace Pyramid
{
    public class Program
    {
        private static void Pyramid(int height)
        {
            for (int line = 0; line < height; line++)
            {
                for (int leadingSpace = 0; leadingSpace < height - line - 1; leadingSpace++)
                {
                    Console.Write(' ');
                }
                
                for (int star = 0; star < (line * 2) + 1 ; star++)
                {
                    Console.Write('*');
                }

                Console.WriteLine();
            }
        }
        
        public static void Main(string[] args)
        {
            Pyramid(5);
        }
    }
}