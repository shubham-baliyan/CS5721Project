
using BLL.BookingObserver;
using BLL.Interfaces;
using DAL.DALClasses;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.ServiceClass
{
    public class Pool : IArena, IObserver
    {
        private ArenaDAL _arenaDAL = new ArenaDAL();
        public int GetCapacity()
        {
            return _arenaDAL.GetPoolCapacity();
        }
        public Tuple<TimeSpan, TimeSpan> GetOpenAndCloseTime()
        {
            return _arenaDAL.GetPoolOpenCloseTime();
        }

        public string CheckCapacity(List<SlotModel> slotList)
        {
            string message = null;
            int totalCapacity = slotList.Sum(x => Convert.ToInt32(x.Capacity));
            if (totalCapacity > GetCapacity())
            {
                message = "Total Capacity is greater than the gym capacity";
            }
            return message;
        }

        public List<SlotModel> CreateSlots(CreateSlotModel createSlotModel)
        {
            createSlotModel.StartTime = new TimeSpan(9, 00, 00);
            createSlotModel.EndTime = new TimeSpan(18, 00, 00);

            List<SlotModel> slotList = new List<SlotModel>();
            if (createSlotModel.Dates.Count() > 0)
            {
                foreach (var dates in createSlotModel.Dates)
                {

                    TimeSpan date3 = new DateTime(2012, 12, 25, 9, 00, 00).TimeOfDay;
                    while (date3 != createSlotModel.EndTime)
                    {
                        if (slotList.Count == 0)
                        {
                            SlotModel slot = new SlotModel()
                            {
                                StartTime = createSlotModel.StartTime,
                                EndTime = new TimeSpan(createSlotModel.StartTime.Hours, createSlotModel.StartTime.Minutes + createSlotModel.Interval, createSlotModel.StartTime.Seconds),
                                Status = true,
                                Date = dates,
                                ArenaId = 2
                            };
                            slotList.Add(slot);
                            date3 = slot.EndTime;
                        }
                        else
                        {
                            SlotModel slot = new SlotModel()
                            {
                                StartTime = date3,
                                EndTime = new TimeSpan(date3.Hours, date3.Minutes + createSlotModel.Interval, date3.Seconds),
                                Status = true,
                                Date = dates,
                                ArenaId = 2
                            };
                            slotList.Add(slot);
                            date3 = slot.EndTime;
                        }
                    }
                }
            }
            return slotList;

        }

        public string AddSlots(List<SlotModel> slotList)
        {
            return _arenaDAL.AddSlots(slotList);
        }

        public bool UpdateSlots(List<SlotModel> slotList)
        {
            return _arenaDAL.UpdateSlots(slotList);
        }

        public bool DeleteSlots(DateTime slotDate)
        {
            return _arenaDAL.DeleteSlots(slotDate, 2);
        }

        public List<SlotModel> GetSlots(DateTime slotDate)
        {
            return _arenaDAL.GetSlotsForCustomer(slotDate, 2);
        }
        public List<SlotModel> GetUpcomingSlots()
        {
            return _arenaDAL.GetSlots(2);
        }
        public List<DateTime> GetDatesWithSlots()
        {
            return _arenaDAL.GetPoolDatesWithSlots();
        }
        public List<SlotModel> GetSlotsForDate(DateTime date)
        {
            return _arenaDAL.GetSlotsForDate(date, 1);
        }
        public int GetSlotCapacity(int slotId)
        {
            return _arenaDAL.GetSlotCapacity(slotId, 1);
        }
        public void BookingChanged(BookingModel bookingModel)
        {
            _arenaDAL.UpdateSlotCapacity(bookingModel.BookingId, bookingModel.SlotId, 2);
        }




    }
}