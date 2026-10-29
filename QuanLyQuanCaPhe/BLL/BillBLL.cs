
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe.BLL
{
    public class BillBLL
    {
        private static BillBLL _instance;
        private readonly CoffeeManagementEntities1 _context;

        private BillBLL()
        {
            _context = new CoffeeManagementEntities1();
        }

        public static BillBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BillBLL();
                }
                return _instance;
            }
        }

        public void InsertBill(int idTable)
        {
           
                var bill = new Bill
                {
                    DateCheckInBill = DateTime.Now,
                    DateCheckOutBill = null,
                    StatusBill = false,
                    Discount = 0,
                    TotalPrice = 0,
                    IdTable = idTable
                };
                var table = _context.TableFoods.FirstOrDefault(t => t.IdTable == idTable);
                if (table != null)
                {
                    table.StatusTable = "Có người";             
                }
           
            _context.Bills.Add(bill);
            _context.SaveChanges();
        }

        public int GetMaxIDBill()
        {
            return _context.Bills.Any() ? _context.Bills.Max(b => b.IdBill) : 0;
        }

        public int GetTotalBillCount()
        {
            return _context.Bills.Count();
        }

        public List<Bill> GetBillByDateAndPage(int page)
        {
            int pageRow = 10;
            var allBills = _context.Bills.OrderBy(b => b.IdBill).ToList();
            List<Bill> result = new List<Bill>();

            int startIndex = (page - 1) * pageRow;
            int endIndex = startIndex + pageRow;

            for (int i = startIndex; i < endIndex && i < allBills.Count; i++)
            {
                result.Add(allBills[i]);
            }

            return result;
        }


        public int GetNumBillByDate()
        {
            return _context.Bills.Count();
        }

        public int GetUncheckBillIDByTableID(int idTable)
        {
            var bill = _context.Bills
                .FirstOrDefault(b => b.IdTable == idTable && !b.StatusBill);
            if (bill != null)
                return bill.IdBill;
            else
                return -1;

        }

        public void Payment(int idBill, int discount, double finalTotalPrice)
        {
            var bill = _context.Bills.FirstOrDefault(b => b.IdBill == idBill);
            if (bill != null)
            {
                bill.DateCheckOutBill = DateTime.Now;
                bill.StatusBill = true;
                bill.Discount = discount;
                bill.TotalPrice = finalTotalPrice;

                var table = _context.TableFoods.FirstOrDefault(t => t.IdTable == bill.IdTable);
                if (table != null)
                {
                    table.StatusTable = "Trống";
                }

                _context.SaveChanges();
            }
        }

        public Bill GetBillById(int idBill)
        {
            return _context.Bills.FirstOrDefault(b => b.IdBill == idBill);
        }

        public TableFood GetTableById(int idTable)
        {
            return _context.TableFoods.FirstOrDefault(t => t.IdTable == idTable);
        }

        public Bill GetBillByTableId(int idTable)
        {
            return _context.Bills.FirstOrDefault(b => b.IdTable == idTable && !b.StatusBill);
        }

        public void AddBill(Bill bill)
        {
            _context.Bills.Add(bill);
            _context.SaveChanges();
        }
    }
}