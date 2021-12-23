using System;
using System.Collections.Generic;
using System.Text;

namespace LAB4_CH
{
    class PaperComparer : IComparer<Paper>
    {
        int IComparer<Paper>.Compare(Paper p1, Paper p2)
        {
            return p1.author.Surname.CompareTo(p2.author.Surname);
        }
    }
}

