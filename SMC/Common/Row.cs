using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    
    public class Row
    {
        public const int RowLength = 3;
        private List<SlotType> slots;
        decimal? coefficient = null;

        public List<SlotType> Slots { get => slots; set => slots = value; }

        string rowString = "";
        
        public string RowString
        {
            get
            {
                if (rowString == "")
                {
                    slots.ForEach(x =>
                    {
                        switch (x)
                        {
                            case SlotType.Apple:
                                rowString += 'A';
                                break;
                            case SlotType.Bnana:
                                rowString += 'B';
                                break;
                            case SlotType.Pineapple:
                                rowString += 'P';
                                break;
                            case SlotType.Wildcard:
                                rowString += '*';
                                break;
                        }
                    });
                }
                
                return rowString;
            }
        }

        public decimal Coefficient
        {
            get
            {
                if (coefficient != null)
                {
                    return coefficient.Value;
                }

                var firstSlot = slots[0];
                coefficient = SlotValue(slots[0]);

                for (int i = 1; i < slots.Count; i++)
                {
                    if (slots[i] == firstSlot)
                    {
                        coefficient += SlotValue(slots[i]);
                    }
                    else if (slots[i] != SlotType.Wildcard)
                    {
                        coefficient = 0;
                        break;
                    }
                }

                return coefficient.Value;
            }
        }

        decimal SlotValue(SlotType slot)
        {
            decimal result = 0;
            switch (slot)
            {
                
                case SlotType.Apple:
                    result = (decimal)0.4;
                    break;
                case SlotType.Bnana:
                    result = (decimal)0.6;
                    break;
                case SlotType.Pineapple:
                    result = (decimal)0.8;
                    break;
                default:
                    result = 0;
                    break;
            }

            return result;
        }

        public Row(List<SlotType> _slots)
        {
            this.slots = _slots;
        }
    }
}
