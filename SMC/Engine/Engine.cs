using System;
using System.Collections.Generic;
using Common;

namespace Engine
{
    public class SMEngine : IEngine
    {
        public Row GetRow(Random r = null)
        {
            var seed = DateTime.Now.Millisecond;
            if (r == null)
            {
                r = new Random(seed);
            }

            List<SlotType> slots = new List<SlotType>();
            for (int i = 0; i < Row.RowLength; ++i)
            {
                var number = r.Next(1, 100);
                if (number < 46)
                {
                    slots.Add(SlotType.Apple);
                }
                else if (number < 81)
                {
                    slots.Add(SlotType.Bnana);
                }
                else if (number < 96)
                {
                    slots.Add(SlotType.Pineapple);
                }
                else
                {
                    slots.Add(SlotType.Wildcard);
                }
            }
            Row row = new Row(slots);

            return row;
        }

        public List<Row> GetRows(int number)
        {
            var seed = DateTime.Now.Millisecond;
            Random r = new Random(seed);

            List<Row> result = new List<Row>();
            for (int i = 0; i < number; i++)
            {
                result.Add(GetRow(r));
            }

            return result;
        }
    }
}
