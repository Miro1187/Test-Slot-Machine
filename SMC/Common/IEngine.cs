using System;
using System.Collections.Generic;

namespace Common
{
    public interface IEngine
    {
        Row GetRow(Random r);
        List<Row> GetRows(int number);
    }
}
