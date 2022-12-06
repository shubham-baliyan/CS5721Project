using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Interfaces
{
    public interface IArena
    {
        int GetCapacity();
        Tuple<TimeSpan, TimeSpan> GetOpenAndCloseTime();
        string CheckCapacity(List<SlotModel> slotList);
        List<SlotModel> CreateSlots(CreateSlotModel createSlotModel);
        string AddSlots(List<SlotModel> slotList);
        bool UpdateSlots(List<SlotModel> slotList);
        bool DeleteSlots(DateTime slotDate);
        List<SlotModel> GetSlots(DateTime slotDate);
        List<SlotModel> GetUpcomingSlots();
        List<DateTime> GetDatesWithSlots();
        List<SlotModel> GetSlotsForDate(DateTime date);
        int GetSlotCapacity(int slotId);

    }
}
