using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Contracts;

namespace EelsAndEscalators.ClassicEandE
{
    public class ClassicBoard : IBoard
    {
        public int size { get; } = 30;
        public List<IPawn> Pawns { get; set; }
        public List<IEntity> Entities { get; set; }

        //XD
        public ClassicBoard()
        {
            Pawns = new List<IPawn>();
            Entities = new List<IEntity>();
        }

        public string CreateOutput()
        {

            var fields = 30;
            double ratio = 9.0 / 16.0;

            var fieldCount_x = (int)Math.Sqrt(ratio * fields);
            var fieldCount_y = fields / fieldCount_x; //ratio * fieldCount_y;
            if (fields % fieldCount_x != 0)
                fieldCount_y++;

            string[,] array2D = new string[fieldCount_y, fieldCount_x];
            string result = "";

            var counter = 1;

            for (var y = 0; y < fieldCount_y; ++y)
            {

                for (var x = 0; x < fieldCount_x; ++x)
                {
                    var xOffs = y % 2 == 0 ? x : fieldCount_x - x - 1;
                    var stringDigit = $"      {counter} ";
                    stringDigit = stringDigit.Substring(stringDigit.Length - 4);

                    if (counter <= fields)
                        array2D[y, xOffs] = string.Format("{0}[ | , | ] ", stringDigit);
                    else
                        array2D[y, xOffs] = "".PadLeft(14, ' ');

                    counter++;
                }
            }


            for (var y = 0; y < fieldCount_y; ++y)
            {
                for (var x = 0; x < fieldCount_x; ++x)
                    result += array2D[y, x];

                result += "\n";
            }





            return result;
        }
    }
}
