using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidLibrary.Models
{
    public class CustomPyramid : Pyramid
    {
        public CustomPyramid(int numberOfRows) : base(numberOfRows)
        {
            CardRows = new();
            CreateCardRows(numberOfRows);
        }
    }
}
